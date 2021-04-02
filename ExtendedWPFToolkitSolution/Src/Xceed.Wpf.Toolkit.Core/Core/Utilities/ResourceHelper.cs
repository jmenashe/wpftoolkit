/*************************************************************************************
   
   Toolkit for WPF

   Copyright (C) 2007-2020 Xceed Software Inc.

   This program is provided to you under the terms of the XCEED SOFTWARE, INC.
   COMMUNITY LICENSE AGREEMENT (for non-commercial use) as published at 
   https://github.com/xceedsoftware/wpftoolkit/blob/master/license.md 

   For more features, controls, and fast professional support,
   pick up the Plus Edition at https://xceed.com/xceed-toolkit-plus-for-wpf/

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

  ***********************************************************************************/

using System.IO;
using System.Reflection;
using System.Resources;

namespace Xceed.Wpf.Toolkit.Core.Utilities
{
  internal class ResourceHelper
  {
    internal static Stream LoadResourceStream( Assembly assembly, string resId )
    {
      string basename = System.IO.Path.GetFileNameWithoutExtension( assembly.ManifestModule.Name );
      ResourceManager resourceManager = new ResourceManager( basename, assembly );
            var resources = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            var fmtId = resId.Replace("/", ".").Replace("\\", ".");
            var resourceName = $"{basename}.{fmtId}";
      // resource names are lower case and contain only forward slashes
      resId = resId.ToLower();
      resId = resId.Replace( '\\', '/' );
            var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream != null)
                return stream;
      return ( resourceManager.GetObject( resId ) as Stream );
    }
  }
}
