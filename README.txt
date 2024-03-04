Changelog :

Version 0.4.8 :
- Change : Cleaning code for ActionRepeatSequence classes
- Add : Sequence can be repeated infinitly in Action "Repeat sequence"
- Add : Progress on localization

Version 0.4.7 :
- Add : PostBuild script to create a .zip containing all files needed to run
- Change : Cleaning code for ActionKey classes
- Change : Cleaning code for ActionImageSearch classes
- Add : Progress on localization

Version 0.4.6 :
- Fix : Preventing crash when selecting action "Wait" or "Repeat sequence" in Action View
- Add : Constant for coloring label and areas XY and XY2

Version 0.4.5 :
- Add : Areas can now be colored
- Add : Colored labels and rectangles in "Action Click" panel
- Add : Areas updating position when coordinates changes in "Action Click" panel
- Change : Cleaning code for ActionClick classes
- Add : Progress on localization

Version 0.4.4 :
- Fix : Removed currently loaded sequence from being selectable in action view "Sequence" and "ImageSearch" to prevent unwanted infinite loop

Version 0.4.3 :
- Add : Check if there is unsaved changes before closing
- Add : Check if there is unsaved changes before changing sequence

Version 0.4.2 :
- Fix : Bot cannot be started multiple times while running
- Fix : Updating buttons "Start/Stop", "Edit action" and "Delete selected actions" state if there is no action in the list

Version 0.4.1 :
- Change : No longer possible to resize HotKey View
- Fix : Updating button "Delete selected actions" state when no action is selected
- Fix : Updating button "Edit action" state when no action is selected
- Fix : Updating button "Start/Stop" state if there is no action in the list
- Fix : Updating button "Delete sequence" state if there is no sequence selected
- Fix : Updating numbox "X2", "Y2" and trackbar "dragspeed" state when editing action
- Fix : Bot action Click behavior not moving properly in drag mode
- Add : SplitContainer in MainApp for ListboxAction and ListBoxLog
- Change : Save sequence View now has focus on Textbox
- Change : Hotkey View Added space between GroupBox bot and XY

Version 0.4.0 :
- Fix : Expiration Time not autofilling when editing Action ImageSearch
- Add : New functionnalities in Action Click
- Add : Progress on localization
- Add : Progress on prevention crash when loading sequences from old versions

Version 0.3.0 :
- Add : Semantic versionning implemented
- Add : New action Image Search
- Add : Progress on logs handling
- Change : DEPRECATED : Action Picture Wait replaced by Action Image Search
- Change : DEPRECATED : Action If Picture replaced by Action Image Search