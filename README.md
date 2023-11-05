# SQL Format 大綱

## 項目分配

> Sulli &rarr; TargetFormat

> Littletrainee &rarr; SourceFormt

<br>

## 範例
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
### III. 2級範本
```SQL
SELECT e.Name, e.Age, s.Name
FROM Employee AS e
JOIN Sexual AS s
e.Sexual = s.ID;
```
### IV. 3級範本
```SQL
SELECT e.Name, e.Age s.Name, d.Name
FROM ( Employee AS e
        JOIN Sexual AS s
        e.Sexual = s.ID
)
JOIN Department AS d
e.Department = d.Id;
```
<br>

## Ini格式規範
1. 各個 **[變數]** 或 **[關鍵字]** 之間必須要有空格，否則會無法做判斷。
2. 暫定 **[縮排]** 為 **[4]** 格
3. FROM Table 部分 **[不換行]**
4. 關鍵字必須 **[大寫]**
5. 欄位名稱 **[字首大寫]**
6. 別名 **[小寫]**
7. 分號 **[不獨立一行]**
8. JOIN **[不縮排]**
9. 字串 用 **[單引號(')]** 包覆
10. 下一階的內容要基於上一階 **[再縮排]**
11. 左括號 **[ ( ]**  **[不獨立一行]**
12. 右括號 **[ ) ]**  **[獨立一行]**