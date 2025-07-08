-- Создание таблицы Categorys
CREATE TABLE Categorys (
    Id          INT             NOT NULL PRIMARY KEY,
    Name        NVARCHAR(50)    NOT NULL
);

-- Создание таблицы Items
CREATE TABLE Items (
    Id          INT             NOT NULL PRIMARY KEY,
    Name        NVARCHAR(255)   NOT NULL,
    Price       FLOAT           NULL,
    Description NVARCHAR(1000)  NULL,
    IdCategory  INT             NULL,
    
    -- Внешний ключ на таблицу Categorys
    CONSTRAINT FK_Items_Categorys 
        FOREIGN KEY (IdCategory) 
        REFERENCES Categorys(Id)
);