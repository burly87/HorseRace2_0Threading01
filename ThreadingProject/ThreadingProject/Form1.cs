using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadingProject
{
    public partial class Form1 : Form
    {
        private ArrayList bwArray;
        private ArrayList threadLabels;             // List of labels displayed in FlowLayoutPanel mainPanel
        private FormsUpdater formsUpdater;
        private WaitThread wT;

        // Isolated Storage
        private IsoStorageHandler isoStorageHandler;

        // start button Pressed
        bool isRunning = false;

        public Form1()
        {
            InitializeComponent();

            formsUpdater = new FormsUpdater(this);
            wT = new WaitThread(this);

            int[] numbers = { 1, 2, 3, 4 };

            //numbericUpDown to choose how long the threads should run
            timer.Maximum = 2000;
            timer.Minimum = 0;

            //comboBox number to choose how many threads to run
            number.DataSource = numbers;
            number.SelectedIndex = 0;

            //Dictionary choises to populate the threads CB
            Dictionary<int, string> choices = new Dictionary<int, string>();
            choices.Add(1, "Threads");
            choices.Add(2, "Threads Queue");
            choices.Add(3, "Background Worker");

            //comboBox threads to pick if BW or Threads to run
            threads.DataSource = new BindingSource(choices, null);
            threads.DisplayMember = "Value";
            threads.ValueMember = "Key";
            threads.SelectedIndex = 0;

            //Isolated Storage
            isoStorageHandler = new IsoStorageHandler();

        }

        /// <summary>
        /// Update FlowLayoutPanel mainPanel to display if in Thread or BachgroundWorker mode
        /// </summary>
        private void UpdateView()
        {
            if (threads.SelectedItem != null && number.SelectedItem != null) //For first Start
            {
                var selectedItem = (KeyValuePair<int, string>)threads.SelectedItem;

                //select Threads
                if (selectedItem.Key == 1 || selectedItem.Key == 2)
                {
                    mainPanel.Controls.Clear();

                    threadLabels = new ArrayList();


                    for (int i = 0; i < (int)number.SelectedItem; i++)
                    {
                        FlowLayoutPanel panel = new FlowLayoutPanel();
                        panel.AutoScroll = true;
                        panel.FlowDirection = FlowDirection.TopDown;
                        panel.WrapContents = false;

                        Label threadLabel = new Label();
                        threadLabel.Text = "Thread " + (i + 1);
                        panel.Controls.Add(threadLabel);

                        Label timeLabel = new Label();
                        timeLabel.Text = "Ready!";
                        timeLabel.AutoSize = true;
                        panel.Controls.Add(timeLabel);

                        threadLabels.Add(timeLabel);

                        mainPanel.Controls.Add(panel);

                    }
                }
                // select BachgroundWorker 
                else
                {
                    mainPanel.Controls.Clear();
                    bwArray = new ArrayList();

                    for (int i = 0; i < (int)number.SelectedItem; i++)
                    {
                        FlowLayoutPanel panel = new FlowLayoutPanel();
                        panel.AutoScroll = true;
                        panel.FlowDirection = FlowDirection.TopDown;
                        panel.WrapContents = false;

                        Label threadLabel = new Label();
                        threadLabel.Text = "Background Worker " + (i + 1);
                        panel.Controls.Add(threadLabel);

                        Label timeLabel = new Label();
                        timeLabel.AutoSize = true;
                        timeLabel.Text = "";
                        panel.Controls.Add(timeLabel);

                        ProgressBar bar = new ProgressBar();
                        panel.Controls.Add(bar);

                        WaitBW bw = new WaitBW(bar, timeLabel, formsUpdater);

                        bwArray.Add(bw);

                        mainPanel.Controls.Add(panel);

                    }
                }
                
            }

        }

        /// <summary>
        /// en or disable elements of Form while running 
        /// </summary>
        /// <param name="disable"></param>
        public void BlockControls(bool disable) 
        {
            if (disable)
            {
                threads.Enabled = false;
                number.Enabled = false;
                timer.Enabled = false;
                isRunning = true;
                startStop.Text = "Stop";
            }
            else
            {
                threads.Enabled = true;
                number.Enabled = true;
                timer.Enabled = true;
                isRunning = false;
                startStop.Text = "Start";
            }

        }

        /// <summary>
        /// Btn to stop running 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startStop_Click(object sender, EventArgs e)
        {
            // get Item from ComboBox to decide what to do
            var selectedItem = (KeyValuePair<int, string>)threads.SelectedItem;
            // get time placed in timer
            int time = ((int)timer.Value * 1000);
            // get number of Threads selected (max 4)
            int numberOfThreads = (int)number.SelectedItem;

            if (!isRunning)
            {
                totalTime.Text = ""; // Reset Labels!
                // Test if Start is divideable by No. of Threads so they can share the work
                if (time % numberOfThreads == 0)
                {
                    if (selectedItem.Key == 1 || selectedItem.Key == 2)
                    {

                        //wT = new WaitThread(time/numberOfThreads, numberOfThreads, this);
                        wT.SetTime(time, numberOfThreads);
                        wT.Start(selectedItem.Key);
                        BlockControls(true);
                        foreach (Label label in threadLabels)
                        {
                            label.Text = "Running for " + time / numberOfThreads + " ms";
                        }

                    }
                    //BackgroundWorker
                    else
                    {
                        BlockControls(true);
                        formsUpdater.Reset(); //Reset FormsUpdater for the next start
                        for (int i = 0; i < bwArray.Count; i++)
                        {
                            WaitBW bw = (WaitBW)bwArray[i];
                            bw.StartWorker(time / numberOfThreads);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("This Number is not perfectly divisible, Please choose another one!");
                }

            }
            else //background Worker
            {
                if (selectedItem.Key == 1)
                {
                    wT.Abort();
                }
                else
                {
                    for (int i = 0; i < bwArray.Count; i++)
                    {
                        WaitBW bw = (WaitBW)bwArray[i];
                        bw.InterruptWorker(); //Interrupt Background Worker
                    }
                    BlockControls(false);
                }

            }
        }

        // ------- Event handler --------

        private void threads_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateView();
        }

        private void number_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateView();
        }

        public void SetTotalTimeLabel(String text)
        {
            totalTime.Text = text;
        }

        public void SetAllThreadLabels(String text)
        {
            foreach (Label label in threadLabels)
            {
                label.Text = text;
            }
        }

        public delegate void labelHandler(String text);
        public delegate void controlsHandler(bool b);


        public void onThreadEvent(object src, ThreadEventArgs args)
        {
            // 
            if (timer.InvokeRequired)
            {
                // status finished work -> set labels
                if (args.status == 1)
                {
                    labelHandler del = new labelHandler(SetAllThreadLabels);
                    this.Invoke(del, new object[] 
                    { 
                        "Finished!"
                    });

                    del = new labelHandler(SetTotalTimeLabel);
                    this.Invoke(del, new object[] 
                    {
                        "All Threads are finished!" 
                    });
                }
                // abored called -> set labels 
                else if (args.status == 2)
                {
                    labelHandler del = new labelHandler(SetAllThreadLabels);
                    this.Invoke(del, new object[] 
                    {
                        "Aborted!"
                    });

                    del = new labelHandler(SetTotalTimeLabel);
                    this.Invoke(del, new object[] 
                    { 
                        "This Action was aborted!"
                    });
                }
                // Error occured -> set labels
                else
                {
                    labelHandler del = new labelHandler(SetAllThreadLabels);
                    this.Invoke(del, new object[] { "Error!" });

                    del = new labelHandler(SetTotalTimeLabel);
                    this.Invoke(del, new object[] { "An error occured!" });
                }
                controlsHandler cDel = new controlsHandler(BlockControls);
                this.Invoke(cDel, new object[] { false });
            }
            else
            {
                if (args.status == 1)
                {
                    SetAllThreadLabels("Aborted!");
                    SetTotalTimeLabel("All Threads are finished");
                }
                else if (args.status == 2)
                {
                    SetAllThreadLabels("Aborted!");
                    SetTotalTimeLabel("This action was aborted!");
                }
                else
                {
                    SetAllThreadLabels("Error!");
                    SetTotalTimeLabel("An error occured!");
                }
                BlockControls(false);
            }
        }

        // Isolated Storage
        /// <summary>
        /// Write to Iso Storage
        /// </summary>
        /// <param name="time"></param>
        public void WriteToIso(int time)
        {
            isoStorageHandler.WriteToStorage(time);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}