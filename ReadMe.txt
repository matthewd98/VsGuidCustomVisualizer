Once the custom visualizer is compiled, it must be copied to either one of the following directories:

C:\Program Files (x86)\Microsoft Visual Studio\<vsVersion>\<VsEdition>\Common7\Packages\Debugger\Visualizers\, e.g.C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\Packages\Debugger\Visualizers\

OR

C:\Users\Matthew\Documents\<vsNameAndVersion>\Visualizers, e.g. C:\Users\Matthew\Documents\Visual Studio 2019\Visualizers

There's a post-build script in the project to automate this.