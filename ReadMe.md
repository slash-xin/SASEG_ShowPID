# Show the Windows PID of both EG process and SAS process in SEGuide window title

A custom task which can add Windows Process ID (PID) of both EG process and background SAS process into the EG title bar. It works by running the custom task "Show PID" after you open the SAS Enterprise Guide.

![](pics\result.png)



This custom task is based on Chris Hemedinger's Job. Here is the link: https://github.com/cjdinger/SEGuideShowPI Sometimes I also need the PID of SAS process behind the SEGuide, so I add this feature.

To use the task:

- Copy the bin\Release\ShowPID.dll to %SASHome%\SASEnterpriseGuide\<version>\Custom, where <version> is the version of SAS Enterprise Guide you're running.
- You might need to create the Custom subfolder in that location.
- The task should work with SAS  Enterprise Guide 6.1 and later.
- You might need to "unblock" the DLL [per these instructions](http://blogs.sas.com/content/sasdummy/2013/05/19/unblocking-custom-task-dlls/)

## Here is how to use it

1. Open SAS Enterprise Guide and Click "Tools" -> "Add-in" -> "Show PID", like this:

   ![](pics\toolsmenu.png)

2. After you click it, the task will be running:

   ![](pics\running.png)

3. When the task is finished, the task icon is disappeared, and the PID infor is added to the Title.

   ![](pics\finish.png)

