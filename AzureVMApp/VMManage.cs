using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace AzureVMApp
{
    public partial class frmVMManager : Form
    {
        Microsoft.Azure.Management.ResourceManager.Fluent.Authentication.AzureCredentials credentials = null;
        Microsoft.Azure.Management.Fluent.Azure azure;

        string _groupName = string.Empty;
        
        public frmVMManager()
        {
            InitializeComponent();

            try
            {
                toolStripStatusLabel1.Text = "Attempting to get Azure config file";

                credentials = SdkContext.AzureCredentialsFactory.FromFile(@"azureauth.properties");

                if (credentials != null)
                {
                    lstBoxLog.Items.Add(toolStripStatusLabel1.Text);

                    azure = (Azure)Azure
                        .Configure()
                        .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                        .Authenticate(credentials)
                        .WithDefaultSubscription();

                    FillResourceGroups();
                    toolStripStatusLabel1.Text = "";

                    btnDeallocate.BackColor = Color.Gray;
                    btnStart.BackColor = Color.Gray;
                    btnStop.BackColor = Color.Gray;
                }
                else
                {
                    MessageBox.Show("Error in retreiving AzureAuth File. Please review the pre-requisites in README and try again");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //this.Close();
            }
           

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                lstBoxLog.Items.Add("Starting VM");
                string ipAddress = string.Empty;
                foreach (KeyValuePair<string, string> item in lstVM.SelectedItems)
                {
                    var vm = azure.VirtualMachines.GetByResourceGroup(_groupName, item.Key);
                    PowerOnVM(vm);                   
                }

                lstBoxLog.Items.Add("VM Start operation initiated");
                MessageBox.Show("VM Start initated");                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void PowerOnVM(IVirtualMachine virtualMachine)
        {
            string vmName = virtualMachine.ComputerName;
            Task task = virtualMachine.StartAsync();
            await task;
            lstBoxLog.Items.Add(vmName + " Started at " + DateTime.Now);
            lstBoxLog.Items.Add(vmName + " IPAddress : " + virtualMachine.GetPrimaryPublicIPAddress().IPAddress);
            UpdateVMData(null, null);
        }



        private void ShowMessage()
        {
            throw new NotImplementedException();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (KeyValuePair<string, string> item in lstVM.SelectedItems)
                {
                    lstBoxLog.Items.Add("Powering off VM : " + item);
                    var vm = azure.VirtualMachines.GetByResourceGroup(_groupName, item.Key);
                    PowerOffVM(vm);
                    lstBoxLog.Items.Add(item + " VM PoweredOff: ");
                }
                
                MessageBox.Show("VM Stopped");                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void PowerOffVM(IVirtualMachine virtualMachine)
        {
            string vmName = virtualMachine.ComputerName;
            Task task = virtualMachine.PowerOffAsync();
            await task;
            lstBoxLog.Items.Add(vmName + "stopped at " + DateTime.Now);
            UpdateVMData(null, null);
        }

        private void FillResourceGroups()
        {
            toolStripStatusLabel1.Text = "Filling Resource Group Information";
            var rGroup = azure.ResourceGroups.List();
            

            foreach (var item in rGroup)
            {
                cmbResourceGroup.Items.Add(
                    item.Name
                    );                
            }

            cmbResourceGroup.SelectedIndex = 0;

            cmbResourceGroup.SelectedIndexChanged += UpdateVMData;
        }
                
        private void UpdateVMData(object sender, EventArgs e)
        {
            //lstVM.Items.Clear();
            toolStripStatusLabel1.Text = "Filling VM Details for ResourceGroup " + _groupName;

            _groupName = cmbResourceGroup.SelectedItem.ToString();

            Dictionary<string, string> list = new Dictionary<string, string>();

            foreach (var item in azure.VirtualMachines.ListByResourceGroup(_groupName))
            {
                lstBoxLog.Items.Add("Getting VM Status for " + item.ComputerName);
                foreach (InstanceViewStatus stat in item.InstanceView.Statuses)
                {
                    string[] statusData = stat.Code.Split('/');
                    if (statusData[0].Equals("PowerState"))
                    {
                        list.Add(item.ComputerName, statusData[1]);
                    }                   
                }                                
            }

            lstVM.DataSource = new BindingSource(list, null); 
            lstVM.DisplayMember = "Key";
            lstVM.ValueMember = "Value";

            /*(lstVM.Items.Add(
                    item.ComputerName
                   );*/
            toolStripStatusLabel1.Text = "";


        }

        private void lstVM_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            btnDeallocate.Enabled = false;

            btnDeallocate.BackColor = Color.Gray;
            btnStart.BackColor = Color.Gray;
            btnStop.BackColor = Color.Gray;

            var state = (KeyValuePair<string,string>)lstVM.SelectedItem;

            if (state.Value.Equals("running"))
            {
                btnStop.Enabled = true;
                btnStop.BackColor = Color.DarkRed;
                btnDeallocate.Enabled = true;
                btnDeallocate.BackColor = Color.DarkOrange;
            }
            else if(state.Value.Equals("stopped") || state.Value.Equals("deallocated"))
            {
                btnStart.Enabled = true;
                btnStart.BackColor = Color.Green;
            }
        }

        private void btnDeallocate_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (KeyValuePair<string, string> item in lstVM.SelectedItems)
                {
                    lstBoxLog.Items.Add("Deallocating VM : " + item.Key);
                    var vm = azure.VirtualMachines.GetByResourceGroup(_groupName, item.Key);
                    DeallocateVM(vm);
                    lstBoxLog.Items.Add(item.Key + " VM Deallocated");
                }

                MessageBox.Show("VM Deallocated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void DeallocateVM(IVirtualMachine virtualMachine)
        {
            string vmName = virtualMachine.ComputerName;
            Task task = virtualMachine.DeallocateAsync();
            await task;
            lstBoxLog.Items.Add(vmName + " deallocated at " + DateTime.Now);
            UpdateVMData(null, null);
        }
    }

}
