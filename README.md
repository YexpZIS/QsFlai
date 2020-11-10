QsFlai
====
**Quick square for launcher app icons.**

Описание:
**Like Fences, but OpenSource.**<br>
Приложение помогает освободить рабочий стол от файлов. На данный момент нельзя изменять внешний вид приложения через само приложение. Кастомизация приложения происходит, посредством изменения файла конфигурации. Данный файл генерируется в папку с приложением под названием "QsFlai.settings".



Демонстрация приложения
----

![back to future](source/demo/back_to_future.gif)
![cyberpank](source/demo/cyberpank.gif)
![default](source/demo/default.gif)



Настройки приложения GUI
----

Чтобы открыть файл/папку/приложение достаточно один раз кликнуть на него.

#### 0. Переход в режим редактирования

Для того, чтобы перейти в режим редактирования нужно нажать правой кнопкой мыши на название окна и выбрать в выпадающем меню пункт "Edit mode".

#### 1. Изменение названия экземпляра

Нужно перейти в режим редактирования. Двойной клик по названию окна. После этого действия станет доступен TextBox, в котором можно изменить название экземпляра.

#### 2. Перемещение окна

Для перемещения окна в произвольную позицию нужно перейти в режим редактирования окна и потянуть за верхнюю половину окна, в месте, где отсутствует текст.

#### 3. Изменение размеров окна

Нужно перейти в режим редактирования, после этого достаточно потянуть за любой угол окна.

#### 4. Добаление нового окна

Клик правой кнопкой мыши по названию окна, в открывшемся меню нужно выбрать пункт "Add window", после данного действия появится новое окно в левом вержнем углу экрана.

### 5. Закрыть окно

Нужно кликнуть правой кнопкой мыши по названию окна и в выпадающем списке выбрать пункт "Close window". После этого появится диалоговое окно с возможностью выбора:<br> 
    1. Полного закрытия окна(Да) - после перезапуска приложения окно не появится.<br>
    2. Частичного закрытия окна(Нет) - после перезапуска приложения окно снова появится.<br>
    3. Отмену действия(Отмена) - диалоговое окно закроется.<br>

#### 6. Перезагрузка приложения

Нужно кликнуть правой кнопкой мыши по названию окна и в выпадающем списке выбрать пункт "Reolad app". После данного действия приложения закроет все окна, прочитает конфигурационный файл("QsFlai.settings") и в соответствии с этим файлом создаст окна.

#### 7. Закрыть приложение

Нужно кликнуть правой кнопкой мыши по названию окна и в выпадающем списке выбрать пункт "Shutdown app". После выбора данного пункта приложение завершит работу.

#### 8. Добавление файлов/папок/программ в приложение

Нужно перейти в режим редактирования и перетащить нужные файлы/папоки/программы в окно программы.

#### 9. Сохранение настроек 

После изменения размеров, названия, количества окон и т.д. Нужно сохранить настройки. Чтобы это сделать нужно кликнуть правой кнопкой мыши по названию окна и выбрать пункт "Save".



Настройки приложения через конфирурационный файл "QsFlai.settings"
----

В данном файле настройки хранятся в формате JSON.

    [
        { Настройуи 1-го окна },
        { Настройуи 2-го окна },
        { Настройуи 3-го окна }
    ]

Настройки x-го окна разделены на несколько груп:

    [
        {
            "id":"", // Внутреннй идентификатор окна. У кажндго окна должен быть уникальный идентификатор.
            "border":{}, // Настройки отвечающие за внешний вид верхней части окна
            "BackgroundImage":"", // Изображение на заднем плане. Может быть null
            "isImgStaticSize":"", // Будет ли изображение менять свои размеры при анимации разворачивания и сворачивания окна.
            "Position":"", // Позиция окна на экране
            "Scale":{}, // Размеры окна
            "Animation":{}, // Данный блок отвечает за настройку анимации окна
            "filesSettings":{}, // Настройки файлов(Например ширина и высота).
            "Files":[ {},{} ], // Список файлов
            "editMode":{} // Настройки окна при нахождении его в режиме редактирования
        }
    ]

Рассмотрим каждый параметор отдельно.

1. ```"id":"0"``` - любое целое число от -100 000 до 100 000
2. ```"border":{"Name":"Window","BorderColor":"#80000000","TextColor":"#FFFFFFFF","FontFamily":"Segoe UI","FontSize":20.0,"TextHeight":40,"BorderHeight":30}``` 

    2.1 ```"Name":"Window"``` - Название окна 

    2.2 ```"BorderColor":"#80000000"``` - Цвет верхней части окна 

    ![BorderColor](source/doc/BorderColor.jpg) 

    2.3 ```"TextColor":"#FFFFFFFF"``` - Цвет названия окна

    ![TextColor](source/doc/TextColor.jpg)

    2.4 ```"FontFamily":"Segoe UI"``` - Шрифт названия окна

    ![FontFamily](source/doc/FontFamily.jpg)

    2.5 ```"FontSize":20.0``` и ```"TextHeight":40``` редактируются вместе т.к. 'Label' не умеет работать с размерами шрифтов.

    2.5.1 ```"FontSize":20.0``` - Размер шрифта

    2.5.2 ```"TextHeight":40``` - Высота 'Label'

    ![FontSize&TextHeight](source/doc/FontSize&TextHeight.jpg)

    2.6 ```"BorderHeight":30``` - Высота верхней части окна (Вместе с данным параметром нужно менять значение ```Scale":{"Initial":"...,30"``` в блоке ```"Scale":{}```. Эти два значения в большинстве случаев должны совпадать.)

    ![BorderHeight](source/doc/BorderHeight.jpg)

3. ```"BackgroundImage":""``` - Изображение на заднем плане окна. Изображение должно находиться в одной папке с приложением. (Рекомендуется менять с параметрами: ```"BorderColor":"#80000000"```, ```"editMode":{"originalColor":"#64000000"```)

    ![BackgroundImage](source/doc/BackgroundImage.jpg)

4. ```"isImgStaticSize":"true"``` - Будет ли изображение менять свои размеры при анимации. Может принимать значения ```true```/```false```.

    ![isImgStaticSize](source/doc/isImgStaticSize.gif)

5. ```"Position":"100,512"``` - Позиция окна на экране

6. ```"Scale":{"Initial":"120,30","Final":"280,150"}``` - Размеры окна.

    6.1 ```"Initial":"120,30"``` - Начальный размер.

    ![ScaleInitial](source/doc/ScaleInitial.jpg)

    6.2 ```"Final":"280,150"``` - Конечный размер

    ![ScaleFinal](source/doc/ScaleFinal.jpg)

7. ```"Animation":{"Speed":1000}``` - Настройка анимации окна

    7.1 ```"Speed":1000``` - Скорость анимации окна

    ```250```/```1000```

    ![AnimationSpeed](source/doc/AnimationSpeed.gif)

8. ```"filesSettings":{"Size":"80,110","blockHeight":40.0,"Margin":"1,1,1,1","TextColor":"#FFFFFFFF","FontFamily":"Agency FB","FontSize":20.0,"BackgroundColor":"#80000000","BorderColor":"#FF000000","BorderSize":"1,1,1,1"}``` - Настройки файлов

    8.1 ```"Size":"80,110"``` - Размер файла

    ```70,70``` / ```80,110```

    ![filesSettingsSize](source/doc/filesSettingsSize.jpg)

    8.2 ```"blockHeight":40.0``` - Ширина изображения

    ```20.0``` / ```40.0```

    ![filesSettingsblockHeight](source/doc/filesSettingsblockHeight.jpg)

    8.3 ```"Margin":"1,1,1,1"``` - Отступы от файлов

    ```Справа, сверху, слева, снизу``` = ```"1,1,1,1"```

    ```"10,1,30,5"``` / ```"1,1,1,1"```

    ![filesSettingsMargin](source/doc/filesSettingsMargin.jpg)

    8.4 ```"TextColor":"#FFFFFFFF"``` - Цвет текста

    ![filesSettingsTextColor](source/doc/filesSettingsTextColor.jpg)

    8.5 ```"FontFamily":"Agency FB"``` - Шрифт текста

    ![filesSettingsFontFamily](source/doc/filesSettingsFontFamily.jpg)

    8.6 ```"FontSize":20.0``` - Размер текста

    ```30.2``` / ```20```

    ![filesSettingsFontSize](source/doc/filesSettingsFontSize.jpg)

    8.7 ```"BackgroundColor":"#80000000"``` - Цвет блока

    ![filesSettingsBackgroundColor](source/doc/filesSettingsBackgroundColor.jpg)

    8.8 ```"BorderColor":"#FF000000"``` - Цвет каемки файла

    ![filesSettingsBorderColor](source/doc/filesSettingsBorderColor.jpg)

    8.9 ```"BorderSize":"1,1,1,1"``` - Толщина каемки файла

    ```Справа, сверху, слева, снизу``` = ```"1,1,1,1"```

    ```"10,5"``` / ```"1,1,1,1"```

    ![filesSettingsBorderSize](source/doc/filesSettingsBorderSize.jpg)

9. ```"Files":[ {"id":0,"Name":null,"Image":null,"Link":"Blender"},{"id":1,...} ]``` - Список файлов

    9.1 ```"id":0``` - Уникальный идентификатор файла

    9.2 ```"Name":"Roll"``` - Название файла. Если данный параметор имеет значение ```null```, то название файла определяется по ```Link``` файла. Данный параметор создан, чтобы можно было давать произвольные названия файлам.

    9.3 ```"Image":"img.png"``` - Изображение отображаемое вместо иконки файла

    ![FilesImage](source/doc/FilesImage.jpg)

    9.4 ```"Link":"C://Blender"``` - Полный путь к файлу


10. ```"editMode":{"originalColor":"#64000000","colors":["#5AFF0000","#64000000"]}}``` - Настройки окна при нахождении его в режиме редактирования

    10.1 ```"originalColor":"#64000000"``` - Стандартный цвет окна

    10.2 ```"colors":["#5AFF0000","#64000000",...]``` - Коллекция цветов, которыми будет переливаться окно в режиме редактирования.

    ![editModecolors](source/doc/editModecolors.gif)

Установка программы
----
Для установки данной программы на ПК требуестся скачать файл ```QsFlai\bin\Release\QsFlai.exe``` и поместить данный файл в любую папку на компьютере. В данной папке будут храниться настройки приложения и картинки. После данного этапа требуется создать ярлык ссылающийся на программу и поместить данный ярлык в папку автозагрузки Windows(```%userprofile%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup```). 


Схема
----

![architecture](source/application architecture/architecture.png)