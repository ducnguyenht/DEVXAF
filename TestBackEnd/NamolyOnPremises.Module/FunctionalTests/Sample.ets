;#DropDB NamolyOnPremisesEasyTest

#Application NamolyOnPremises.Win
#Application NamolyOnPremises.Web

#IfDef NamolyOnPremises.Win

*Action About...
 
*Action OK

#EndIf

#IfDef NamolyOnPremises.Web

*Action Choose Theme(Black Glass)

#EndIf
