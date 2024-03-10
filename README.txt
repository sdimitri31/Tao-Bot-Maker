Changelog :

Version 0.4.20 :
- Add : Action "Key" has been changed to "Text"

Version 0.4.19.2 :
- Fix : Better calculation for mouse drag

Version 0.4.19.1 :
- Fix : Improved localization about saving sequence, action "wait" and action names
- Fix : Cleaning code

Version 0.4.19 :
- Add : Action "Sequence" now deprecated, use action "Repeat sequence" instead
- Add : New version of LogFramework.dll
- Fix : Action "Wait" wasn't recovering old data in xml properly
- Fix : Error message when loading action was still showing after editing
- Fix : Labels X2 and Y2 not coloring in action "Click" view
- Fix : "Move Click" not selected anymore when checking "Double Click" in action "Click" view

Version 0.4.18 :
- Add : Action "Wait" can now be between 2 values
- Add : Different units of time can be selected in Action "Wait" 
- Fix : Selecting the previous successfully loaded sequence when there is an error loading an other sequence

Version 0.4.17 :
- Add : Now possible to move the mouse without making any click
- Add : Now possible to do a click where the mouse is currently located

Version 0.4.16.1 :
- Fix : Improved verifications on loading xml

Version 0.4.16 :
- Fix : MessageBox doesn't show anymore when saving a new sequence
- Fix : Loading sequence doesn't cause crash anymore when loading action with invalid parameters

Version 0.4.15 :
- Add : Default value for XY2 in action ImageSearch View set to max screen size
- Add : Search area and clic area drawn when selected in action add/edit view
- Add : Search area and clic area drawn when coords are changed
- Add : Coordinates doesn't needs to be top left and bottom right corners anymore when looking for image

Version 0.4.14.1 :
- Fix : Prevent crash when loading corrupted sequence

Version 0.4.14 :
- Fix : Prevent crash when entering value above int32 range

Version 0.4.13 :
- Fix : Labels X and Y were not properly coloring 
- Add : HotKey View now color duplicated hotkeys

Version 0.4.12 :
- Change : Add/Edit Action form redesigned
- Change : UI colors improved

Version 0.4.11 :
- Fix : First sequence not loading when selected for the first time
- Fix : MessageBox alerting for changes showing everytime after an action was edited even when no changes were made after loading

Version 0.4.10 :
- Change : Cleaning code for ActionWait classes
- Add : Progress on localization

Version 0.4.9 :
- Change : Cleaning code for ActionSequence classes

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