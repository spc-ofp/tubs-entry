// -----------------------------------------------------------------------
// <copyright file="TripService.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.TubsEntry.Modules.Trip.Services
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
    using System.Windows.Controls;
    using Spc.Ofp.TubsEntry.Modules.Trip.ViewModels;
    using Spc.Ofp.TubsEntry.Modules.Trip.Views;

    /// <summary>
    /// TripService abstracts away the creation of a type-specific ViewModel
    /// from the data model.
    /// </summary>
    public class TripService
    {
        public TripViewModel GetTrip(int tripId)
        {
            var rand = new Random();
            var tvm = new TripViewModel();
            tvm.TripId = tripId;
            tvm.Title = String.Format("XYZ / 09-0{0}", rand.Next(10));
            tvm.Tabs = new ObservableCollection<TabItem>()
            {
                new TabItem{ Header = "PS-1", Content = new Ps1View() },
                new TabItem{ Header = "GEN-1 (Sightings)"},
                new TabItem{ Header = "GEN-1 (Transfers)"},
                new TabItem{ Header = "GEN-2"},
                new TabItem{ Header = "GEN-3"},
            };
            
            return tvm;
        }
    }
}
