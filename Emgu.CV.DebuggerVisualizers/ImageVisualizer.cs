//----------------------------------------------------------------------------
//  Copyright (C) 2004-2019 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using Microsoft.VisualStudio.DebuggerVisualizers;
using Emgu.CV;
using Emgu.CV.UI;
using System.Diagnostics;

[assembly: DebuggerVisualizer(typeof(Emgu.CV.DebuggerVisualizers.ImageVisualizer), Target = typeof(Image<,>))]
[assembly: DebuggerVisualizer(typeof(Emgu.CV.DebuggerVisualizers.MatVisualizer), Target = typeof(Mat))]
[assembly: DebuggerVisualizer(typeof(Emgu.CV.DebuggerVisualizers.UMatVisualizer), Target = typeof(UMat))]

namespace Emgu.CV.DebuggerVisualizers
{
    public sealed class ImageVisualizer : BaseImageVisualizer
    {
    }

    public sealed class MatVisualizer : BaseImageVisualizer
    {
    }

    public sealed class UMatVisualizer : BaseImageVisualizer
    {
    }

    public class BaseImageVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            IInputArray image = objectProvider.GetObject() as IInputArray;
            if (image != null)
            {
                using (ImageViewer viewer = new ImageViewer())
                {
                    viewer.Image = image;
                    windowService.ShowDialog(viewer);
                }
            }
        }
    }
}
