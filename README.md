# RunForTheRoses
This console app uses the list of running horses from the 2016 Kentucky Derby. The app provides a list of horses in random order, asks for the user's name and then prompts the user to pick a horse from the list. If the user picks a horse that is not on the list, the code goes in a loop until the user picks a horse from the list. Once the user picks the horse, the result of the horse's finishing position is displayed to the console and then written to a text file. 

To run the program, from github, open the project in visual studio, open the studio and run/start.
My dataset is the Json file 2016RunForTheRosesResults.json. It gets deserialized to be used to display the list of horses on the screen and to display the horses place once the horse is selected. The answer is stored as an object by allowing the user to save their result as a text file or json file. The saver class is the base class for the inherited classes PlainTextSaver and JsonSaver. The object is then able to be loaded in on the next application run. 

If you  add a breakpoint at approx. line # 139 where it says return derby results to see the list of horses(per the streaming video). 
you can confirm and  look at the list of horses and continue the program.

To confirm the file is written to text is correct and what is recalled correctly, the file HorseBet is in the binDebug/Release folder titled HorseBet.Depending on how the results is saved, the file will be a txt or Json file.
