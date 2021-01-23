

--Insert Values Movies
INSERT INTO Movies VALUES ('Superman', 'SuperHeroes', 16, 50, 50, 'https://upload.wikimedia.org/wikipedia/en/thumb/1/10/Superman_Returns.jpg/220px-Superman_Returns.jpg');
INSERT INTO Movies VALUES ('Wonderwoman', 'SuperHeroes', 16, 50, 50, 'https://images-na.ssl-images-amazon.com/images/I/81ugxFdBZBL._SL1500_.jpg');
INSERT INTO Movies VALUES ('Batman v Superman', 'SuperHeroes', 16, 50, 50, 'https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6166/6166913_sa.jpg;maxHeight=640;maxWidth=550');
INSERT INTO Movies VALUES ('The Hunger Games', 'Science Fiction', 16, 50, 50, 'https://m.media-amazon.com/images/M/MV5BMTAyMjQ3OTAxMzNeQTJeQWpwZ15BbWU4MDU0NzA1MzAx._V1_UX182_CR0,0,182,268_AL_.jpg');
INSERT INTO Movies VALUES ('Twilight', 'Science Fiction', 14, 50, 50, 'https://sos.oregon.gov/blue-book/PublishingImages/explore/movies/twilight.jpg');
INSERT INTO Movies VALUES ('Star Wars', 'Science Fiction', 14, 50, 50, 'https://i.pinimg.com/originals/02/d6/3c/02d63cb25b454f37abfe7143913db194.jpg');
INSERT INTO Movies VALUES ('Tangled', 'Animation', 8, 20, 50, 'https://upload.wikimedia.org/wikipedia/en/a/a8/Tangled_poster.jpg');
INSERT INTO Movies VALUES ('Toy Story 4', 'Animation', 8, 20, 50, 'https://images-na.ssl-images-amazon.com/images/I/714hR8KCqaL._AC_SL1308_.jpg');
INSERT INTO Movies VALUES ('Zootopia', 'Animation', 8, 20, 50, 'https://mypostercollection.com/wp-content/uploads/2018/05/Zootopia-Poster-1.jpg');
INSERT INTO Movies VALUES ('Central Intelligence', 'Comedia', 16, 50, 50, 'https://images-na.ssl-images-amazon.com/images/I/81ioA49NNgL._AC_SL1500_.jpg');
INSERT INTO Movies VALUES ('Bridesmaids', 'Comedia', 16, 50, 50, 'https://images-na.ssl-images-amazon.com/images/I/51tjTM%2BGCsL._AC_.jpg');
INSERT INTO Movies VALUES ('Just Go With It', 'Comedia', 16, 50, 50, 'https://upload.wikimedia.org/wikipedia/en/thumb/b/b8/Just_Go_with_It_Poster.jpg/220px-Just_Go_with_It_Poster.jpg');

--Insert Values Hall
INSERT INTO Hall VALUES (1, 5,5);
INSERT INTO Hall VALUES (2, 5,5);
INSERT INTO Hall VALUES (3, 5,5);

--Insert Values Screeninngs

INSERT INTO Screenings VALUES ('Superman','10:00','2021-02-01','1');
INSERT INTO Screenings VALUES ('Superman','19:00','2021-02-01','1');
INSERT INTO Screenings VALUES ('Superman','10:00','2021-02-03','2');
INSERT INTO Screenings VALUES ('Superman','19:00','2021-02-03','2');
INSERT INTO Screenings VALUES ('Superman','19:00','2021-01-01','2');

INSERT INTO Screenings VALUES ('Wonderwoman','10:00','2021-02-01','3');
INSERT INTO Screenings VALUES ('Wonderwoman','19:00','2021-02-01','3');
INSERT INTO Screenings VALUES ('Wonderwoman','10:00','2021-02-02','2');
INSERT INTO Screenings VALUES ('Wonderwoman','19:00','2021-02-02','2');
INSERT INTO Screenings VALUES ('Wonderwoman','10:00','2021-02-03','1');

INSERT INTO Screenings VALUES ('Batman v Superman','19:00','2021-02-01','2');
INSERT INTO Screenings VALUES ('Batman v Superman','19:00','2021-02-03','3');
INSERT INTO Screenings VALUES ('Batman v Superman','19:00','2021-02-03','1');
INSERT INTO Screenings VALUES ('Batman v Superman','19:00','2021-02-04','2');
INSERT INTO Screenings VALUES ('Batman v Superman','19:00','2021-02-04','1');

INSERT INTO Screenings VALUES ('The Hunger Games','10:00','2021-02-02','1');
INSERT INTO Screenings VALUES ('The Hunger Games','10:00','2021-02-07','3');
INSERT INTO Screenings VALUES ('The Hunger Games','10:00','2021-02-07','1');

INSERT INTO Screenings VALUES ('Twilight','19:00','2021-02-07','2');
INSERT INTO Screenings VALUES ('Twilight','12:00','2021-02-07','3');
INSERT INTO Screenings VALUES ('Twilight','12:00','2021-02-07','1');

INSERT INTO Screenings VALUES ('Star Wars','19:00','2021-02-08','1');
INSERT INTO Screenings VALUES ('Star Wars','10:00','2021-02-08','2');
INSERT INTO Screenings VALUES ('Star Wars','12:00','2021-02-08','3');

INSERT INTO Screenings VALUES ('Tangled','17:00','2021-02-08','1');
INSERT INTO Screenings VALUES ('Tangled','19:00','2021-02-08','2');
INSERT INTO Screenings VALUES ('Tangled','09:00','2021-02-08','2');

INSERT INTO Screenings VALUES ('Toy Story 4','17:00','2021-02-08','3');
INSERT INTO Screenings VALUES ('Toy Story 4','11:00','2021-02-08','1');
INSERT INTO Screenings VALUES ('Toy Story 4','09:00','2021-02-08','1');

INSERT INTO Screenings VALUES ('Zootopia','17:00','2021-02-09','3');
INSERT INTO Screenings VALUES ('Zootopia','11:00','2021-02-09','1');
INSERT INTO Screenings VALUES ('Zootopia','09:00','2021-02-09','1');


INSERT INTO Screenings VALUES ('Central Intelligence','11:00','2021-02-09','3');
INSERT INTO Screenings VALUES ('Central Intelligence','17:00','2021-02-09','1');
INSERT INTO Screenings VALUES ('Central Intelligence','19:00','2021-02-09','1');

INSERT INTO Screenings VALUES ('Bridesmaids','11:00','2021-02-09','2');
INSERT INTO Screenings VALUES ('Bridesmaids','16:00','2021-02-09','2');
INSERT INTO Screenings VALUES ('Bridesmaids','19:00','2021-02-09','2');

INSERT INTO Screenings VALUES ('Just Go With It','11:00','2021-02-10','3');
INSERT INTO Screenings VALUES ('Just Go With It','10:00','2021-02-09','1');
INSERT INTO Screenings VALUES ('Just Go With It','17:00','2021-02-09','2');

--Insert admin to users

INSERT INTO Users VALUES ('admin@gmail.com','admin','123456','admin');