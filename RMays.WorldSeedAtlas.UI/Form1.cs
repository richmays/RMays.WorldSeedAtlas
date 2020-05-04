using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMays.WorldSeedAtlas.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected LocationList locationList;

        private string CurrentPosition
        {
            get
            {
                return txtStartingPosition.Text;
            }
            set
            {
                txtStartingPosition.Text = value;
            }
        }

        private void txtStartingPosition_TextChanged(object sender, EventArgs e)
        {
            // Recalculate items in the list.
            if (!IsValid(CurrentPosition)) return;
            UpdateLocations();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            locationList = new LocationList("locations.json");
            UpdateLocations();
        }

        private void UpdateLocations()
        {
            clbLocations.Items.Clear();

            var LocationsToAdd = new List<SmartLocation>();
            foreach(var item in locationList)
            {
                if (item.Checked && this.chkHideCheckedLocations.Checked)
                {
                    continue;
                }

                item.RecalculateDistance(CurrentPosition);
                LocationsToAdd.Add(item);
            }

            LocationsToAdd.Sort();
            foreach (var location in LocationsToAdd)
            {
                clbLocations.Items.Add(location.ToString(), location.Checked);
            }
        }

        private bool IsValid(string currentLocation)
        {
            if (string.IsNullOrWhiteSpace(currentLocation))
            {
                return false;
            }

            if (currentLocation.Length < 2 || currentLocation.Length > 3)
            {
                return false;
            }

            return true;
        }

        private void clbLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Record all the checks.  Also, if something was unchecked, remove the check.
            for (var i = 0; i < clbLocations.Items.Count; i++)
            {
                var locationName = locationList.ElementAt(i).Name;
                var isChecked = clbLocations.CheckedItems.Contains(locationList.ElementAt(i).ToString());
                locationList.First(x => x.Name == locationName).Checked = isChecked;
            }

            /*
            foreach(var item in clbLocations.CheckedItems)
            {
                var location = locationList.Where(x => x.ToString() == item.ToString()).FirstOrDefault();
                location.Checked = true;
            }
            */

            UpdateLocations();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (var item in locationList)
            {
                item.Checked = false;
            }

            UpdateLocations();
        }
    }
}

