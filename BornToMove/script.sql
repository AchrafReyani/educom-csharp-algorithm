-- Maak de tabel 'Move' aan als deze nog niet bestaat
CREATE TABLE IF NOT EXISTS Move (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Description TEXT NOT NULL,
    SweatRate FLOAT NOT NULL
);

-- Voeg de gegeven data toe aan de tabel 'Move'
INSERT INTO Move (Name, Description, SweatRate) VALUES
('Push up', 'Ga horizontaal liggen op teentoppen en handen. Laat het lijf langzaam zakken tot de neus de grond bijna raakt. Duw het lijf terug nu omhoog tot de ellebogen bijna gestrekt zijn. Vervolgens weer laten zakken. Doe dit 20 keer zonder tussenpauzes', 3),
('Planking', 'Ga horizontaal liggen op teentoppen en onderarmen. Houdt deze positie 1 minuut vast', 3),
('Squat', 'Ga staan met gestrekte armen. Zak door de knieën tot de billen de grond bijna raken. Ga weer volledig gestrekt staan. Herhaal dit 20 keer zonder tussenpauzes', 5),
('Lunge', 'Sta rechtop met voeten op heupbreedte. Stap één voet naar voren en zak door de knie totdat beide knieën een hoek van 90 graden vormen. Duw jezelf terug omhoog naar de startpositie en herhaal met het andere been. Doe dit 15 keer per been.', 4),
('Pull up', 'Hang aan een horizontale stang met een bovenhandse greep. Trek jezelf omhoog tot je kin boven de stang uitkomt en laat je dan gecontroleerd zakken. Herhaal dit 10 keer.', 5),
('Dips', 'Plaats je handen op de rand van een bankje of stoel en strek je benen voor je uit. Laat je lichaam zakken door je ellebogen te buigen tot ze een hoek van 90 graden vormen en duw jezelf dan weer omhoog. Herhaal dit 15 keer.', 4),
('Pistol squat', 'Sta op één been en strek het andere been voor je uit. Zak door je knie op het steunbeen tot je zo laag mogelijk zit, en kom dan weer omhoog. Herhaal dit 10 keer per been.', 5);