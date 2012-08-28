// -----------------------------------------------------------------------
// <copyright file="TripViewModel.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.TubsEntry.Modules.Trip.ViewModels
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
    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.ViewModel;
    using Microsoft.Practices.Prism.Regions;
    using System.Windows.Controls;
    using System.ComponentModel;
    using Spc.Ofp.TubsEntry.Modules.Trip.Services;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class TripViewModel : NotificationObject, INavigationAware
    {
        public ObservableCollection<TabItem> Tabs { get; set; }

        public TripViewModel()
        {
            // This code is here for debugging look and feel of the view
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                this._title = "XYZ / 11-01";
                Tabs = new ObservableCollection<TabItem>()
                {
                    // Can set DataContext for TabItem here, if that helps...
                    new TabItem{ Header = "GEN-1 (Sightings)"},
                    new TabItem{ Header = "GEN-1 (Transfers)"},
                    new TabItem{ Header = "GEN-2"},
                    new TabItem{ Header = "GEN-3"},
                };
            }
                

        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    this.RaisePropertyChanged(() => this.Title);
                }
            }
        }

        private int _tripId;
        public int TripId
        {
            get { return _tripId; }
            set
            {
                if (value != _tripId)
                {
                    _tripId = value;
                    this.RaisePropertyChanged(() => this.TripId);
                }
            }
        }

        private int? GetRequestedTripId(NavigationContext navigationContext)
        {
            var param = navigationContext.Parameters["TripId"];
            int tripId;
            if (param != null && Int32.TryParse(param, out tripId))
            {
                return tripId;
            }
            return null;
        }
        
        
        #region INavigationAware members
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            // Still not 100% on when to return true and when to return false, but I'll get there...
            var requestedTripId = GetRequestedTripId(navigationContext);
            return requestedTripId.HasValue && requestedTripId.Value == this._tripId;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // TODO If this gets called for a close, then we might want to offer the option
            // of saving.  Otherwise, we don't care about this method.
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var requestedTripId = GetRequestedTripId(navigationContext);
            if (requestedTripId.HasValue)
            {
                // Goofing only!  Inject this or do something better...
                var tripService = new TripService();
                var tvm = tripService.GetTrip(requestedTripId.Value);
                this.TripId = tvm.TripId;
                this.Title = tvm.Title;
                this.Tabs = tvm.Tabs;
                this.RaisePropertyChanged(String.Empty);
            }
        }
        #endregion
    }
}
