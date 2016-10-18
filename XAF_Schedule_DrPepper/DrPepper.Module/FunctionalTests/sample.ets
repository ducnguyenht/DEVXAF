;#DropDB DrPepperEasyTest

#Application DrPepper.Win
#Application DrPepper.Web

*FillForm
 User Name = Admin
*Action Log On

#IfDef DrPepper.Win

*Action About...
 
*Action OK

#EndIf

#IfDef DrPepper.Web

*Action Choose Theme(Black Glass)

#EndIf
