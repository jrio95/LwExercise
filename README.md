# LwExercise

Hi! :wave:

## Usage

I have chosen to implement the functionality of translation of “Hello. How are you?” to/from 5 languages, I have decided to return one language if it is indicated in the Accept-Language header or all languages available if there is no Accept-Language header.

The url of the azure deployment where you cand find the open api documentation is:

<https://lwtestapi.azurewebsites.net/>

Once you get in there, It will show the open api documentation and you can make the request there. The request only has one parameter which is Accept-Language header, there you can choose either what language you want the translation or the language of your browser (default). To get all the translations available since the http call request from a browser automatically fills the Accept-Language header with your browser culture, you can use a http request client such as postman and from there, you can paste the API endpoint:

 <https://lwtestapi.azurewebsites.net/lw/translate>

 And make the request with no Accept-Language header so it will return all the available translations.

## Build and run locally

 To build and run this solution locally, you need to have a sqlserver (2019 version if possible). Once you have the sqlserver, you have to either get in Package Manager Console of your visual studio or in a powershell in administrator mode and go to the Lw.Api directory (..\LwExercise\src\Lw.API) and execute the command:

 ```bash
dotnet ef update database
 ```

 In order to get the database, its tables and the initial data deployed. Once you have done that you just have to build and run the Web Api.
 
 (Note: if you want to deploy it in a non local database, you have to change connectiong string called db placed in appsetting.json file).
 