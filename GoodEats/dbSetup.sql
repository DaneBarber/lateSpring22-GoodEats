-- Active: 1658189439783@@54.187.169.182@3306@classroom_demos

CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS restaurants(
        id int NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'Primary Key',
        name VARCHAR(255) NOT NULL,
        location VARCHAR(255),
        category VARCHAR(255)
    ) default charset utf8 COMMENT '';

drop table restaurants;

CREATE TABLE
    IF NOT EXISTS reviews(
        id int NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'Primary Key',
        rating INT NOT NULL CHECK (rating > 0 AND rating < 6),
        body VARCHAR(255),
        restaurantId INT NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY(restaurantId) REFERENCES restaurants(id) ON DELETE CASCADE,
        FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

DROP table reviews;




SELECT 
    r.*, 
    AVG(rev.rating) as AverageRating,
    COUNT(rev.id) as TotalReviews
    FROM restaurants r
LEFT JOIN reviews rev ON rev.restaurantId = r.id
GROUP BY r.id;



SELECT r.*, a.*, res.* FROM reviews r 
        JOIN restaurants res ON res.id = r.restaurantId
        JOIN accounts a ON a.id = r.creatorId 
        WHERE creatorId = "629f92991449f1ae99772122";


INSERT INTO restaurants(name, location, category)
VALUES("Big B Cheese","Boise","Pizza");


INSERT INTO reviews(rating, body, restaurantId, creatorId)
VALUES(1,"meh", 1, "629f92991449f1ae99772122");

INSERT INTO reviews(rating, body, restaurantId, creatorId)
VALUES(3,"It was Aladeen", 1, "629f92991449f1ae99772122");

INSERT INTO reviews(rating, body, restaurantId, creatorId)
VALUES(3,"Can you say delicioso!", 5, "62dec2a3801db9b7e20daf8c");

INSERT INTO reviews(rating, body, restaurantId, creatorId)
VALUES(2,"Worst place to eat in town there was hair in my food. YUK", 3, "62dec2a3801db9b7e20daf8c");

INSERT INTO reviews(rating, body, restaurantId, creatorId)
VALUES(1,"SO GROSS", 3, "62dec2a3801db9b7e20daf8c");
INSERT INTO reviews(rating, body, restaurantId, creatorId)
VALUES(5,"SOOOOOO GOOOD", 3, "62dec2a3801db9b7e20daf8c");


INSERT INTO reviews(rating, body, restaurantId, creatorId)
VALUES(2,"I over ate here I can't believe they would allow you to eat so much food it is so irresponsible! This place should be forced to take better care of their patrons.", 6, "629f92991449f1ae99772122");




