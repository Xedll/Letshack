# <center>Как развернуть это чудо<center>

## Frontend

1. Установить [Node.Js](https://nodejs.org/en)
2. Убедиться, что в [корневой папке](./frontend/) проекта присутствует .env файл со значением URL сервера (по умолчанию: http://localhost:5044) 
    ```cmd
    > VITE_SITE_URL={{YOUR_SERVER_URL}}
    ```
3. Затем в [корневой папке](./frontend/) открыть терминал и ввести команды для установки зависимостей и запуска проекта:
```sh
$ npm i
$ npm run dev
```

Если все хорошо то вас встретит такой вывод в терминале:
```sh
  VITE v5.2.11  ready in 1046 ms

  ➜  Local:   http://localhost:5173/
  ➜  Network: use --host to expose
  ➜  press h + enter to show help
```

И приложение будет запущено на URL указанном в Local


## Backend

1. Установить [.NET SDK](https://dotnet.microsoft.com/ru-ru/download)
2. открыть терминал в корневой папке проекта и ввести:
```sh 
$ dotnet run --project Letshack.WebAPI
```
3. По умолчанию приложение будет запущено на [http://localhost:](http://localhost:5044)