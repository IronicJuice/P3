-------------------------------------------------------------------- P3 --------------------------------------------------------------------
 
This Blazor web application is a prototype of a reimbursement form and an automatic mail service. The user i required to log in to access 
the form itself. A user must be part of the Google workspace to gain access.



----------------------------------------------------------------get it running---------------------------------------------------------------

To be able to use the program you need to replace the current workspace with your own or request persmission to be added to the users
authorised to log in.

you can request for authorisation via cs-22-sw-3-11@student.aau.dk
or you can replace the client secret and id in appsetting.json

------------------------------------------------------------------- Email ------------------------------------------------------------------

You will need to replace the mail in line 211:
Mail.SendMail(currentuserName, currentuserEmail, currentuserIdentifier, formInfo.Name, "example@gmail.com", 587);
to be able to recieve the unredacted pdf

in Data.account.json for the groups you will need to input the wanted mail for each group instead of example@gmail.com


