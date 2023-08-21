using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Windows.Forms;

namespace MultipleProgramLauncher
{
    public partial class MPL : Form
    {
        private List<string> selectedFiles = new List<string>(); // List to store selected file paths
        private List<int> programDelays = new List<int>();
        public MPL()
        {
            InitializeComponent();
            this.MinimumSize = new Size(400, 200);
        }

        // When the create button is clicked
        private void CreateNewBatch_Click(object sender, EventArgs e)
        {
            HomePanel.Hide();
            CreateBatchPanel.Show();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Button removeButton = (Button)sender;
            int indexToRemove = (int)removeButton.Tag;

            Debug.WriteLine($"\nRemove Button clicked for indexToRemove {indexToRemove}");
            Debug.WriteLine("SelectedFiles before removing:");
            for (int i = 0; i< selectedFiles.Count; i++)
            {
                // Split the path into two parts using the last "\" character as the delimiter
                int lastBackslashIndex = selectedFiles[i].LastIndexOf('\\');
                //string one = selectedFiles[i].Substring(0, lastBackslashIndex);
                //string two = selectedFiles[i].Substring(lastBackslashIndex + 1);
                Debug.Write($"{selectedFiles[i].Substring(lastBackslashIndex + 1)} ");
            }
            Debug.Write("\n");
            //Debug.WriteLine($"{selectedFiles}");
            Debug.WriteLine("ProgramDelays before removing:");
            for (int i = 0; i < programDelays.Count; i++)
            {
                Debug.Write($"{programDelays[i]} ");
            }
            Debug.Write("\n");
            //Debug.WriteLine($"{programDelays}");

            // Remove the corresponding filePathPanel from the TablePanel
            Control[] filePathPanels = TablePanel.Controls.Find("FilePathPanel" + indexToRemove, false);
            
            if (filePathPanels.Length > 0)
            {
                Debug.WriteLine($"NumPanels before = {filePathPanels.Length}");
                Control filePathPanel = filePathPanels[0];
                TablePanel.Controls.Remove(filePathPanel);
                filePathPanel.Dispose();
                Debug.WriteLine($"NumPanels after = {filePathPanels.Length}");
            }

            // Remove the file path and delay from the arrays
            selectedFiles.RemoveAt(indexToRemove);
            programDelays.RemoveAt(indexToRemove);

            Debug.WriteLine("\nSelectedFiles after removing:");
            for (int i = 0; i < selectedFiles.Count; i++)
            {
                int lastBackslashIndex = selectedFiles[i].LastIndexOf('\\');
                Debug.Write($"{selectedFiles[i].Substring(lastBackslashIndex + 1)} ");
            }
            Debug.Write("\n");
            //Debug.WriteLine($"{selectedFiles}");
            Debug.WriteLine("ProgramDelays after removing:");
            for (int i = 0; i < programDelays.Count; i++)
            {
                Debug.Write($"{programDelays[i]} ");
            }
            Debug.Write('\n');
            // Update the Tag property of the remove buttons and delay text boxes
            UpdateTags(indexToRemove);
        }
        /*
        private void UpdateTags(int indexToRemove)
        {
            // Find all the filePathPanels in the TablePanel
            Control[] filePathPanels = TablePanel.Controls.OfType<Panel>().ToArray();

            for (int i = 0; i < filePathPanels.Length; i++)
            {
                // Update the Tag property of the filePathPanel
                filePathPanels[i].Tag = i;

                // Update the Tag property of the remove button
                Control[] removeButtons = filePathPanels[i].Controls.Find("RemoveButton", true);
                if (removeButtons.Length > 0)
                {
                    Button removeButton = (Button)removeButtons[0];
                    removeButton.Tag = i;
                }

                // Update the Tag property of the delay text box
                Control[] delayTextBoxes = filePathPanels[i].Controls.Find("DelayTextBox", true);
                if (delayTextBoxes.Length > 0)
                {
                    TextBox delayTextBox = (TextBox)delayTextBoxes[0];
                    delayTextBox.Tag = i;
                }
            }
        }*/
        private void UpdateTags(int indexToRemove)
        {
            //printPanelsFromTable();
            adjustPanels(indexToRemove);
        }

        private void printPanelsFromTable()
        {
            // Find all the filePathPanels in the TablePanel
            Control[] filePathPanels = TablePanel.Controls.OfType<Panel>().ToArray();
            Debug.WriteLine($"num of panels: {filePathPanels.Length}");
            for (int i = 0; i < filePathPanels.Length; i++)
            {
                int cur = (int)filePathPanels[i].Tag;
                Debug.WriteLine($"Current index = {cur}");
                //now that we have all the attributes we want to work with. we can now edit them if they are at an index that is larger than the index of removal

                Debug.WriteLine($"panel: {filePathPanels[i].Name} tag: {filePathPanels[i].Tag}");

                // get the button and other attributes of the panel they will be index 0 because there are only 1 of each.
                Control[] removeButtons = filePathPanels[i].Controls.OfType<Button>().ToArray();
                if (removeButtons.Length > 0)
                {
                    Button removeButton = (Button)removeButtons[0];
                    Debug.WriteLine($"button: {removeButton.Name} tag: {removeButton.Tag}");
                    //removeButton.Tag = cur - 1; // update the tag for the button
                }
                Control[] delayTextBoxes = filePathPanels[i].Controls.OfType<TextBox>().ToArray();
                if (delayTextBoxes.Length > 0)
                {
                    TextBox delayTextBox = (TextBox)delayTextBoxes[0];
                    Debug.WriteLine($"delay: {delayTextBox.Name} tag: {delayTextBox.Tag}");
                    //delayTextBox.Tag = cur - 1; //update the tag for the textbox
                }
                Control[] filePathLabels = filePathPanels[i].Controls.OfType<Label>().ToArray();
                if (filePathLabels.Length > 0)
                {
                    Label textLabel = (Label)filePathLabels[0];
                    Debug.WriteLine($"text: {textLabel.Name} tag: {textLabel.Tag}");
                    //textLabel.Tag = cur - 1; //update the tag for the label and update its text
                    //Debug.WriteLine($"i = {i}");
                    //textLabel.Text = $"{selectedFiles[i]} + {filePathPanels[i].Tag}";
                }
            }
        }

        private void adjustPanels(int indexToRemove)
        {
            // Find all the filePathPanels in the TablePanel
            Control[] filePathPanels = TablePanel.Controls.OfType<Panel>().ToArray();
            Debug.WriteLine($"num of panels: {filePathPanels.Length}");
            for (int i = 0; i < filePathPanels.Length; i++)
            {
                int cur = (int)filePathPanels[i].Tag;
                Debug.WriteLine($"Current index = {cur}");


                //now that we have all the attributes we want to work with. we can now edit them if they are at an index that is larger than the index of removal
                if (cur > indexToRemove)
                {
                    Debug.WriteLine("OLD panel:");

                    // if the tag is greater than the index, print out the labels and their buttons and stuff
                    Debug.WriteLine($"panel: {filePathPanels[i].Name} tag: {filePathPanels[i].Tag}");
                    //update the tag and Name for the panel
                    filePathPanels[i].Tag = cur - 1;
                    filePathPanels[i].Name = "FilePathPanel" + (cur-1);


                    //Update the name and tag of the button in the panel
                    Control[] removeButtons = filePathPanels[i].Controls.OfType<Button>().ToArray();
                    if (removeButtons.Length > 0)
                    {
                        Button removeButton = (Button)removeButtons[0];
                        Debug.WriteLine($"button: {removeButton.Name} tag: {removeButton.Tag}");
                        removeButton.Tag = cur - 1; // update the tag for the button
                        removeButton.Name = "RemoveButton" + (cur-1);
                    }

                    //update the name and tag of the text box
                    Control[] delayTextBoxes = filePathPanels[i].Controls.OfType<TextBox>().ToArray();
                    if (delayTextBoxes.Length > 0)
                    {
                        TextBox delayTextBox = (TextBox)delayTextBoxes[0];
                        Debug.WriteLine($"delay: {delayTextBox.Name} tag: {delayTextBox.Tag}");
                        delayTextBox.Tag = cur - 1; //update the tag for the textbox
                        delayTextBox.Name = "DelayTextBox" + (cur-1);
                    }
                    Control[] filePathLabels = filePathPanels[i].Controls.OfType<Label>().ToArray();
                    if (filePathLabels.Length > 0)
                    {
                        Label textLabel = (Label)filePathLabels[0];
                        Debug.WriteLine($"text: {textLabel.Name} tag: {textLabel.Tag}");
                        textLabel.Tag = cur - 1; //update the tag for the label and update its text
                        Debug.WriteLine($"i = {i}");
                        textLabel.Text = $"{selectedFiles[i]} + {filePathPanels[i].Tag}";
                        textLabel.Name = "DelayLabel" + (cur-1);
                    }



                    Debug.WriteLine("\nadjusted panel:");
                    Debug.WriteLine($"panel: {filePathPanels[i].Name} tag: {filePathPanels[i].Tag}");

                    // get the button and other attributes of the panel they will be index 0 because there are only 1 of each.
                    if (removeButtons.Length > 0)
                    {
                        Button removeButton = (Button)removeButtons[0];
                        Debug.WriteLine($"button: {removeButton.Name} tag: {removeButton.Tag}");
                    }
                    if (delayTextBoxes.Length > 0)
                    {
                        TextBox delayTextBox = (TextBox)delayTextBoxes[0];
                        Debug.WriteLine($"delay: {delayTextBox.Name} tag: {delayTextBox.Tag}");
                    }
                    if (filePathLabels.Length > 0)
                    {
                        Label textLabel = (Label)filePathLabels[0];
                        Debug.WriteLine($"text: {textLabel.Name} tag: {textLabel.Tag}");
                    }
                    Debug.Write("\n\n");
                }

            }
        }

        private void AddExeFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable Files (*.exe)|*.exe";
            openFileDialog.Title = "Select Executable Files";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file paths
                string[] selectedFilePaths = openFileDialog.FileNames;
                int len = selectedFilePaths.Length;
                Debug.WriteLine($"{len} programs");
                // Save the selected file paths to the list
                selectedFiles.AddRange(selectedFilePaths);
 
                for (int i = 0; i < len; i++) 
                {
                    programDelays.Add(0);
                    
                }
                Debug.WriteLine($"{programDelays.Count} program Delays");
                Debug.WriteLine("Programs:");
                for (int i = 0; i< selectedFiles.Count; i++)
                {
                    int lastBackslashIndex = selectedFiles[i].LastIndexOf('\\');
                    Debug.Write($"{selectedFiles[i].Substring(lastBackslashIndex + 1)} ");
                }
                Debug.Write("\n");
                Debug.WriteLine("Program Delays:");
                for (int i = 0; i< programDelays.Count; i++) 
                {
                    Debug.Write($"{programDelays[i]} ");
                }
                Debug.Write("\n");
                //programDelays = new List<int>(len);
                // Display the file paths in the CreateBatchPanel
                DisplayFilePathsInTable();
            }
        }

        private void DisplayFilePathsInTable()
        {
            // Clear the CreateBatchPanel before displaying the file paths
            //TablePanel.Controls.Clear();

            // Iterate through the selected file paths and display each as a row
            for (int i = 0; i < selectedFiles.Count; i++)
            {

                Panel filePathPanel = new Panel();
                filePathPanel.Name = "FilePathPanel" + i; // Set a unique name for each Panel
                //filePathPanel.Dock = DockStyle.Top;
                filePathPanel.Size = new Size(1033, 100);
                filePathPanel.Tag = i;

                // Create a Label for the file path
                Label filePathLabel = new Label();
                filePathLabel.Name = "FilePathLabel" + i;
                filePathLabel.Text = $"{selectedFiles[i]} + {filePathPanel.Tag}";
                filePathLabel.AutoSize = true;
                filePathLabel.Location = new Point(10, 10);
                filePathLabel.Tag = i;

                // Create a Button to remove the file path
                Button removeButton = new Button();
                removeButton.Text = "Remove";
                removeButton.Name = "RemoveButton" + i; // Set a unique name for each Button
                removeButton.Size = new Size(100, 30);
                removeButton.Location = new Point(10, filePathLabel.Bottom + 5); // Below the file path Label
                removeButton.Click += RemoveButton_Click;
                removeButton.Tag = i;

                // Create a Label for the program delay
                Label delayLabel = new Label();
                delayLabel.Text = "Delay in ms for next program:";
                delayLabel.Name = "DelayLabel" + i;
                delayLabel.AutoSize = true;
                delayLabel.Location = new Point(removeButton.Right + 10, removeButton.Top + 5); // To the right of the remove button

                // Create a TextBox for the program delay input
                TextBox delayTextBox = new TextBox();
                delayTextBox.Width = 100;
                delayTextBox.Name = "DelayTextBox" + i; // Set a unique name for each TextBox
                delayTextBox.Text = "0"; // Set the default value to "0"
                delayTextBox.Size = new Size(70, 20);
                delayTextBox.Tag = i;
                delayTextBox.Location = new Point(delayLabel.Right + 110, removeButton.Top); // To the right of the delay Label
                delayTextBox.TextChanged += DelayTextBox_TextChanged; // Add event handler for delay changes


                // Add the Label, TextBox, and Remove Button to the filePathPanel
                filePathPanel.Controls.Add(filePathLabel);
                filePathPanel.Controls.Add(removeButton);
                filePathPanel.Controls.Add(delayLabel);
                filePathPanel.Controls.Add(delayTextBox);

                // Add the filePathPanel to the CreateBatchPanel
                TablePanel.Controls.Add(filePathPanel);
                //CreateBatchPanel.Controls.Add(filePathPanel);
            }

            // Update the Tag property of the remove buttons
            //UpdateTags();
            // Update the Tag property of the delay text boxes after rearranging the elements
            //UpdateDelayTextBoxTags(); already taken care of in the UpdateRemoveButtonTags()function
        }

        private void DelayTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox delayTextBox = (TextBox)sender;
            int indexToUpdate = (int)delayTextBox.Tag;

            // Update the delay value in the programDelays list when the user changes the TextBox
            int delayMilliseconds;
            if (int.TryParse(delayTextBox.Text, out delayMilliseconds))
            {
                programDelays[indexToUpdate] = delayMilliseconds;
            }
        }

        private void ExportBatch_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Batch Files (*.bat)|*.bat";
            saveFileDialog.Title = "Export Batch File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string batchFilePath = saveFileDialog.FileName;

                using (StreamWriter writer = new StreamWriter(batchFilePath))
                {
                    // Add the @echo off at the top
                    writer.WriteLine("@echo off");

                    for (int i = 0; i < selectedFiles.Count; i++)
                    {
                        // Split the path into two parts using the last "\" character as the delimiter
                        int lastBackslashIndex = selectedFiles[i].LastIndexOf('\\');
                        string one = selectedFiles[i].Substring(0, lastBackslashIndex);
                        string two = selectedFiles[i].Substring(lastBackslashIndex + 1);

                        // Write the 'cd "{one}"' command to navigate to the directory of the EXE file
                        writer.WriteLine("cd \"" + one + "\"");

                        // Write the 'start two' command to open the program
                        writer.WriteLine("start " + two);

                        // Write the 'ping' command to add the specified delay between launching programs
                        int delayMilliseconds = programDelays[i];
                        if (delayMilliseconds > 0)
                        {
                            int seconds = delayMilliseconds / 1000;
                            writer.WriteLine("ping 127.0.0.1 -n 1 -w " + delayMilliseconds);
                        }
                    }
                }

                MessageBox.Show("Batch file exported successfully!", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //most recent version
        }

        // this code below is for the conversion to a .cs file to open the programs.
        /*private void ExportButton_Click(object sender, EventArgs e)
        {
            // Load the template program content
            string templateContent = File.ReadAllText("ProgramTemplate.cs");

            // Replace placeholders with actual data
            string pathsArray = "string[] paths = new string[]\n{\n";
            foreach (string path in selectedFiles)
            {
                pathsArray += $"    \"{path}\",\n";
            }
            pathsArray += "};";

            string delaysArray = "int[] delays = new int[]\n{\n";
            foreach (int delay in programDelays)
            {
                delaysArray += $"    {delay},\n";
            }
            delaysArray += "};";

            // Replace the placeholders in the template content
            templateContent = templateContent.Replace("\"program\"", pathsArray);
            templateContent = templateContent.Replace("1000", delaysArray);

            // Save the modified content to a new file
            string exportFileName = "GeneratedProgram.cs";
            File.WriteAllText(exportFileName, templateContent);

            MessageBox.Show("Program exported successfully!");
        }
        */

        private void EditBatch_Click(object sender, EventArgs e)
        {

        }

    }
}