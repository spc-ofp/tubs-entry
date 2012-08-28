// -----------------------------------------------------------------------
// <copyright file="ModuleTrip.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.TubsEntry.Modules.Trip
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
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;
    using Spc.Ofp.TubsEntry.Modules.Trip.Views;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ModuleTrip : IModule
    {
        public void Initialize()
        {
            // The Unity container is everything
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();

            // Use Prism "view discovery" for views that last for the application's lifetime
            // In the case of TUBS entry, it is the views that are hosted in the navigation region
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            regionManager.RegisterViewWithRegion("NavigatorRegion", typeof(OpenTripsNavigationView));
            regionManager.RegisterViewWithRegion("NavigatorRegion", typeof(ClosedTripsNavigationView));

            // Use Prism "view injection" to fill the workspace region on startup
            // Later this will be replaced with the current trip view
            var welcomeView = container.Resolve<WelcomeView>();
            var region = regionManager.Regions["WorkspaceRegion"];
            region.Add(welcomeView);
            region.Activate(welcomeView);

            // If I have time, circle back and get DI working with NHibernate
            /*
            container.RegisterType<ISession>(new InjectionFactory(c =>
            {
                return TubsDataService.GetSession();
            }));
            */
        }
    }
}
