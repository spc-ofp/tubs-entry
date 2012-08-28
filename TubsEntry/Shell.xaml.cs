// -----------------------------------------------------------------------
// <copyright file="Shell.xaml.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.TubsEntry
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
    using System.Windows;
    using System.Windows.Input;
    
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window
    {
        // This is enough to pull in CommonServiceLocator, Prism, Unity, and the Unity extensions for Prism
        // Install-Package Prism.UnityExtensions

        // This article has steps on getting started with Prism
        // http://www.codeproject.com/Articles/165376/A-Prism-4-Application-Checklist

        // Other stuff to look at:
        // http://www.codeproject.com/Articles/391945/Earth-Quake-A-Composite-WPF-disaster-monitoring-ap
        // http://stackoverflow.com/questions/7710533/accessing-nuget-official-package-source-behind-company-proxy
        
        public Shell()
        {
            InitializeComponent();
        }

        // This is one of those times that we can't get away with a "pure" XAML file
        private void OnExit(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
