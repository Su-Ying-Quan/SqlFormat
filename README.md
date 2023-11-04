# SQL Format 大綱

## 項目分配

> Sulli &rarr; TargetFormat

> Littletrainee &rarr; SourceFormt

<br>

## Ini格式規範
### I. 初級範本
``` SQL
SELECT * FROM Employee;
```

### II. 1級範本
```SQL
SELECT 
    e.Name, e.Age
FROM 
    Employee AS e;
```
1. 各個 **[變數]** 或 **[關鍵字]** 之間必須要有空格。
2. 暫定 **[縮格]** 為 **[4]** 格
3. FROM Table 部分 **[不換行]**
4. 關鍵字必須 **[大寫]**
5. 欄位名稱 **[字首大寫]**
6. 別名 **[小寫]**
7. 分號 **[不獨立一行]**
