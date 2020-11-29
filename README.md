# VsGuidCustomVisualizer

Custom Guid visualizer for Visual Studio debugging to map a Guid variable to a meaningful string.

Once the custom visualizer is compiled, it must be copied to either one of the following directories:

(1) C:\Program Files (x86)\Microsoft Visual Studio\<vsVersion>\<VsEdition>\Common7\Packages\Debugger\Visualizers\, e.g.C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\Packages\Debugger\Visualizers\

(2) C:\Users\Matthew\Documents\<vsNameAndVersion>\Visualizers, e.g. C:\Users\Matthew\Documents\Visual Studio 2019\Visualizers

There's a post-build script in the project to automate this.
