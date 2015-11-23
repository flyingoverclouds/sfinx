# SFinX (SableFin eXtension)
SFinx is a set of library developped in early 2000's using Visual Studio 2003 & .Net 1.1
The code is provided as-is without any warranty.

## SimplePersistance
The most usefull part is a *Objet to Relationnal Mapping* (ORM) library (some years before Linq2SQL) called SimplePersistance
This library use a design time code generator (StoredProcGenerator) to generate C# class to encapsulate Table. 
The class and its properties are tagged with Attribute to host mapping metadata.

The runtime side use a 'dbcontext', which can dynamically generate SQL (or used Storeproc) to query a SQL database.
Compiled version of library has been used in some ASP.Net commercial website in 2002/2003 (including a famous french extrem sport equipment provider).

## DataValidationFramework
This is a *validation framework* which use advanced call interception at the CLR level to apply validation on method call with *ContextBoundObject*
Validation rule are defined with custom Attibrute setted on properties, method parameters.

## Forms
Some helpers functions for early .Net Windows Forms (windows opacity, ...)