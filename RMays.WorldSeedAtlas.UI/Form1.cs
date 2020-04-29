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
                if (!item.Visible)
                {
                    continue;
                }

                if (item.Checked && this.chkHideCheckedLocations.Checked)
                {
                    continue;
                }

                item.RecalculateDistance(CurrentPosition);
                LocationsToAdd.Add(item);
            }

            LocationsToAdd.Sort();
            foreach(var location in LocationsToAdd)
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
            /*
            if (!chkHideCheckedLocations.Checked) return;

            for (var i = 0; i < clbLocations.Items.Count; i++)
            {
                locationList.ElementAt(i).Visible = true;
                locationList.ElementAt(i).Checked = clbLocations.CheckedItems.Contains(locationList.ElementAt(i).ToString());
            }
            */

            /*
            foreach(var item in clbLocations.CheckedItems)
            {
                var location = locationList.Where(x => x.ToString() == item.ToString()).FirstOrDefault();
                location.Checked = true;
                location.Visible = false;
            }
            */
        }
    }
}

