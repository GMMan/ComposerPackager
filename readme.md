Circuits Composer Packager
==========================
This program allows you to create and modify Circuits Composer sample packages.

Usage
-----
- **Open** allows you to open a package. Browse for the package you want to open.
- **New** allows you to create a new package. Browse for where you want to save the new package.
- **Save** allows you to save the currently open package. Note files not referenced by samples are trimmed from the package.
- **Dump** allows you to dump the contents of the currently open package to disk. Select where you want to save the files to.
- **Pack** allows you to pack the contents of a folder into a package file. Choose the folder you want to pack and where you want to save the package to. You don't need to open a package ahead of the time to do this.

The three text fields below the first row of buttons allows you to edit the metadata for the package. Of particular use right now is the Author field.

The list shows you the samples in the package. Select an item to view its info in the "Sample Details" section.

- **Add** allows you to add a new sample.
- **Remove** allows you to remove the currently selected sample.
- **Preview** will allow you to preview the sample once implemented. It is currently disabled.

The "Sample Details" box allows you to edit sample entries. All the text fields should be filled out. You should only use the types available if you want Composer to categorize your sample properly.
Tags are like search terms. It is a comma separated list of terms you can put in Composer's filter field to find other samples with similar tags.

For each of the three parts on the right, if a part exists its file name will be shown. If it is not set, "(none)" will be shown.
- **Replace** allows you to pick a file from your hard drive to set as the part. The file must be in Ogg Vorbis format with an extension of ".ogg". The file name will have "(disk)" in front of it
to indicate that the part will be loaded from disk when the package is saved.
- **Remove** removes the part.

You should have at least one a start part or a loop part. Otherwise, Composer may hang.

Packaging suggestions
---------------------
- Songs depend on the package file name as part of locating samples. Please make your package name unique, and don't change the name once you've released it.
A good naming scheme is "MyName PackName". E.g. "cyanic TestPack"
- Song samples are also very dependent on part names. Once you settle on a file name for a part, don't change the name. You should append the part type if your sample uses multiple parts.
A sample naming scheme is "PackName_SampleSetName_VariantCode[_start/loop/end].ogg". E.g. "testpack_drive_var_a_start.ogg".

To do
-----
- Implement previewing function.