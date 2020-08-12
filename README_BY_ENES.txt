Paketlerde sorun yaşanırsa;

.net core web api için kurulan paket

    CustomerAPI dizinde iken aşağıdaki komutu çalıştırın.

    dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 3.1.7

react(client-app) için kurulan paketler

    client-app dizinde iken aşağıdaki konutu çalıştırın

    npm i bootstrap reactstrap redux react-redux redux-thunk react-router-dom


Uygulama çalıştırma
    .net api için => CustomerAPI klasörü içindeyseniz 
                 * dotnet run
                Ana klasörde iseniz
                 * dotnet run -p CustomerAPI/

    react(client-app) için => clinet-app klasörüne gidin ve aşağıdaki komutu çalıştırın
                 * npm start