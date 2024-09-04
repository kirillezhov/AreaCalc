CREATE TABLE category
(
    id   INT IDENTITY CONSTRAINT category_pk PRIMARY KEY,
    name NVARCHAR(100) NOT NULL CONSTRAINT category_uk UNIQUE
);

INSERT INTO category (name)
VALUES (N'Спорт и отдых'),
       (N'Мебель'),
       (N'Бытовая техника'),
       (N'Игрушки'),
       (N'Еда'),
       (N'Одежда');

CREATE TABLE product
(
    id   INT IDENTITY CONSTRAINT product_pk PRIMARY KEY,
    name NVARCHAR(100) NOT NULL CONSTRAINT product_uk UNIQUE
);

INSERT INTO product (name)
VALUES (N'Мяч'),
       (N'Стул обеденный'),
       (N'Телевизор'),
       (N'Самосвал'),
       (N'Шоколад'),
       (N'Джинсы'),
       (N'Мотоцикл'),
       (N'Кроссовки');

CREATE TABLE product_category
(
    id          INT IDENTITY CONSTRAINT product_category_pk PRIMARY KEY,
    product_id  INT NOT NULL CONSTRAINT product_category_product_id_fk REFERENCES product,
    category_id INT NOT NULL CONSTRAINT product_category_category_id_fk REFERENCES category,

    CONSTRAINT product_category_uk UNIQUE (product_id, category_id)
);

INSERT INTO product_category (product_id, category_id)
VALUES (1, 1), --            Мяч / Спорт и отдых
       (1, 4), --            Мяч / Игрушки
       (2, 2), -- Стул обеденный / Мебель
       (5, 5), --        Шоколад / Еда
       (8, 1), --      Кроссовки / Спорт и отдых
       (8, 6); --      Кроссовки / Одежда

SELECT p.name as 'Product', c.name as 'Category'
FROM product p
         LEFT JOIN product_category pc ON p.id = pc.product_id
         LEFT JOIN category c ON c.id = pc.category_id
ORDER BY 'Product';

-- +--------------+-------------+
-- |Product       |Category     |
-- +--------------+-------------+
-- |Джинсы        |null         |
-- |Кроссовки     |Спорт и отдых|
-- |Кроссовки     |Одежда       |
-- |Мотоцикл      |null         |
-- |Мяч           |Спорт и отдых|
-- |Мяч           |Игрушки      |
-- |Самосвал      |null         |
-- |Стул обеденный|Мебель       |
-- |Телевизор     |null         |
-- |Шоколад       |Еда          |
-- +--------------+-------------+
