# Guards
[![Version](https://img.shields.io/nuget/v/Guards.svg)](https://www.nuget.org/packages/Guards)  [![Downloads](https://img.shields.io/nuget/dt/Guards.svg)](https://www.nuget.org/packages/Guards)

<img src="https://github.com/thomasgalliker/Guards/raw/master/logo.png" alt="Guards" align="right" height="100"> 
This Guards project is a light-weight toolbox which helps you to protect your public interfaces against invalid parameters being passed over. It is one of the fundamentals in object oriented programming that you clearly shield your internals from invalid external signals.


### Download and Install Guards 
This library is available on NuGet: https://www.nuget.org/packages/Guards/ 
Use the following command to install Guards using NuGet package manager console: 

    PM> Install-Package Guards 

You can use this library in any .Net project which is compatible to PCL (e.g. Xamarin Android, iOS, Windows Phone, Windows Store, Universal Apps, etc.) 

### Available Guards
<table>
   <tr>
    <td><b>Category</b></td>
    <td><b>Guards</b></td>
    <td><b>Type of exception
   </tr>
  <tr>
    <td>Boolean</td>
    <td>
        Guard.ArgumentIsTrue<br>
        Guard.ArgumentIsFalse
    </td>
    <td>ArgumentException</td>
    </tr>
    <tr>
    <td>Enumerable</td>
    <td>
        Guard.ArgumentNotNullOrEmpty
    </td>
    <td>ArgumentException</td>
   </tr>
    <tr>
    <td>Null</td>
    <td>
        Guard.ArgumentNull<br>
        Guard.ArgumentNotNull
    </td>
    <td>
        ArgumentException<br>
        ArgumentNullException
    </td>
   </tr>
     <tr>
    <td>Numeric</td>
    <td>
        Guard.ArgumentIsBetween<br>
        Guard.ArgumentIsGreaterOrEqual<br>
        Guard.ArgumentIsGreaterThan<br>
        Guard.ArgumentIsLowerOrEqual<br>
        Guard.ArgumentIsLowerThan<br>
        Guard.ArgumentIsNotNegative<br>
    </td>
    <td>ArgumentOutOfRangeException</td>
   </tr>
    <tr>
    <td>Reflective</td>
    <td>
        Guard.ArgumentMustBeInterface<br>
        Guard.ArgumentMustNotBeInterface
    </td>
    <td>ArgumentException</td>
      </tr>
    <tr>
    <td>String</td>
    <td>
        Guard.ArgumentHasLength<br>
        Guard.ArgumentHasMaxLength<br>
        Guard.ArgumentHasMinLength<br>
        Guard.ArgumentNotNullOrEmpty<br>
        Guard.ArgumentNotNullOrWhiteSpace<br>
    </td>
    <td>
        ArgumentException<br>
        ArgumentException<br>
        ArgumentException<br>
        ArgumentNullException or ArgumentException<br>
        ArgumentNullException or ArgumentException<br>
    </td>
   </tr>
</table>

### API Usage 
The usage of Guards is very easy. 
- Add namespace import `using Guards;`
- Type `Guard.` and select the preferred guard method.

Most of the `Guard` methods provide two overloads: One which takes the guarded parameter as an expression and one that takes the guarded parameter as well as the name (as a string) of the parameter. Take whatever fits you better. Keep in mind that expressions have a minor performance drawback but give you better maintainability. It's all about trade-offs.
```C#
public void AddPerson(string name, Address address)
{
    // Example usage of guards with expressions
    Guard.ArgumentNotNullOrEmpty(() => name);
    Guard.ArgumentNotNull(() => address);
    
    // Example usage of guards withouot expressions
    Guard.ArgumentNotNullOrEmpty(name, nameof(name));
    Guard.ArgumentNotNull(address, nameof(address));
    
    // Further code omitted...
}
``` 

### Contribution 
New guards are added when desired. Since this is an open source project, everyone is highly welcome to contribute and add new guards. However, the proposals should follow the existing pattern. A minimum of governance is required. Thank you for understanding.

### License 
Guards is Copyright &copy; 2019 [Thomas Galliker](https://ch.linkedin.com/in/thomasgalliker). Free for non-commercial use. For commercial use please contact the author. 
