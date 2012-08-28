// -----------------------------------------------------------------------
// <copyright file="OpenTripsNavigationView.xaml.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.TubsEntry.Modules.Trip.Views
{
    /*
     * This file is part of TUBS.
     *
     * TUBS is free software: you can redistribute it and/or modify
     * it under the terms of the GNU Affero General Public License as published by
     * the Free Software Foundation, either version 3 of the License, or
     * (at your option) any later version.
     *  
     * TUBS is distributed in the hope that it will be useful,
     * but WITHOUT ANY WARRANTY; without even the implied warranty of
     * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
     * GNU Affero General Public License for more details.
     *  
     * You should have received a copy of the GNU Affero General Public License
     * along with TUBS.  If not, see <http://www.gnu.org/licenses/>.
     */
    using System.Windows.Controls;
    using Microsoft.Practices.Prism.Regions;
    using Spc.Ofp.TubsEntry.Modules.Trip.Models;
    using Spc.Ofp.TubsEntry.Modules.Trip.ViewModels;
    
    /// <summary>
    /// Interaction logic for OpenTripsNavigationView.xaml
    /// </summary>
    [ViewSortHint("01")]
    public partial class OpenTripsNavigationView : UserControl
    {
        public OpenTripsNavigationView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This "impure" event-handler makes working with a WPF context menu
        /// much easier.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenTripList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewModel = this.DataContext as OpenTripsViewModel;
            if (null != viewModel)
            {
                viewModel.SelectedTrip = this.OpenTripList.SelectedItem as TripSummaryItem;
                // I can't remember, but I think there's a way to fire this for all commands...
                viewModel.LoadTripCommand.RaiseCanExecuteChanged();
                viewModel.FinishTripCommand.RaiseCanExecuteChanged();
                viewModel.DeleteTripCommand.RaiseCanExecuteChanged();
            }
        }
    }
}
