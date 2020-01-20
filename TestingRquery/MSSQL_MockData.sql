use Teste

CREATE TABLE CharacterMock (
id INT IDENTITY(0,1),
Name VARCHAR(64) NOT NULL,
LastName VARCHAR(64) NOT NULL,
UserName VARCHAR(32) NOT NULL UNIQUE,
Password VARCHAR(16) NOT NULL,
Email VARCHAR(32) NOT NULL,
Sex CHAR(1) NOT NULL,
CONSTRAINT PK_CHARACTER PRIMARY KEY(id)
)

CREATE TABLE GameMock (
id INT IDENTITY(0,1),
Name VARCHAR(64) NOT NULL,
ReleaseDate DATE NOT NULL,
GameCast_Id INT,
Description TEXT,
CONSTRAINT PK_GAME PRIMARY KEY(id),
--CONSTRAINT FK_GAME_CAST FOREIGN KEY(GameCast_Id) REFERENCES GameCastMock(id)
)

CREATE TABLE GameCastMock (
id INT IDENTITY(0,1),
Character_Id INT NOT NULL,
Game_Id INT NOT NULL,
CharacterIsMajor BIT NOT NULL DEFAULT 0,
Supporting BIT NOT NULL DEFAULT 0,
Playable BIT NOT NULL DEFAULT 0,
CONSTRAINT PK_CAST PRIMARY KEY(id),
CONSTRAINT FK_CHARACTER FOREIGN KEY(Character_Id) REFERENCES CharacterMock(id),
CONSTRAINT FK_GAMECAST_GAME FOREIGN KEY(Game_Id) REFERENCES GameMock(id)
)

ALTER TABLE GameMock ADD CONSTRAINT FK_GAME_CAST FOREIGN KEY(GameCast_Id) REFERENCES GameCastMock(id)

-- insert data -----------------------

--re0 cast
INSERT INTO GameCastMock VALUES(3, 0, 1, 0, 1)
INSERT INTO GameCastMock VALUES(4, 0, 1, 0, 1)
INSERT INTO GameCastMock VALUES(5, 0, 1, 0, 1)
--re1 cast
INSERT INTO GameCastMock VALUES(3, 1, 1, 0, 1)
INSERT INTO GameCastMock VALUES(5, 1, 1, 0, 1)
INSERT INTO GameCastMock VALUES(6, 1, 1, 0, 1)
INSERT INTO GameCastMock VALUES(7, 1, 1, 0, 1)
INSERT INTO GameCastMock VALUES(8, 1, 1, 0, 0)
INSERT INTO GameCastMock VALUES(9, 1, 0, 1, 0)
--re2 cast
INSERT INTO GameCastMock VALUES(10, 2, 1, 0, 1)
INSERT INTO GameCastMock VALUES(11, 2, 1, 0, 1)
INSERT INTO GameCastMock VALUES(12, 2, 1, 0, 1)
INSERT INTO GameCastMock VALUES(13, 2, 1, 0, 1)
INSERT INTO GameCastMock VALUES(14, 2, 1, 0, 1)
--re3 cast
INSERT INTO GameCastMock VALUES(7, 3, 1, 0, 1)
INSERT INTO GameCastMock VALUES(8, 3, 0, 1, 0)
INSERT INTO GameCastMock VALUES(9, 3, 0, 1, 0)
INSERT INTO GameCastMock VALUES(15, 3, 1, 0, 1)
INSERT INTO GameCastMock VALUES(15, 3, 0, 1, 1)
INSERT INTO GameCastMock VALUES(17, 3, 0, 1, 1)

--Games
INSERT INTO GameMock VALUES('Resident Evil 0','2002-11-12',NULL,'Resident Evil Zero[a] is a survival horror video game developed and published by Capcom. It is the fifth major installment in the Resident Evil series and was originally released for the GameCube in 2002. It is a prequel to Resident Evil (1996), covering the ordeals experienced in the Arklay Mountains by special police force unit, the S.T.A.R.S. Bravo Team. The story follows officer Rebecca Chambers and convicted criminal Billy Coen as they explore an abandoned training facility for employees of the pharmaceutical company Umbrella. The gameplay is similar to other Resident Evil games, but includes a unique "partner zapping" system. The player controls both Rebecca and Billy, switching control between them to solve puzzles and use their unique abilities.');
INSERT INTO GameMock VALUES('Resident Evil 1','1996-03-22',NULL,'Resident Evil[b] is a survival horror video game developed and released by Capcom originally for the PlayStation in 1996, and is the first game in the Resident Evil series. The games plot follows Chris Redfield and Jill Valentine, members of an elite task force known as S.T.A.R.S., as they investigate the outskirts of Raccoon City following the disappearance of their team members. They soon become trapped in a mansion infested with zombies and other monsters. The player, having selected to play as Chris or Jill at the start of the game, must explore the mansion to uncover its secrets.');
INSERT INTO GameMock VALUES('Resident Evil 2','1998-01-21',NULL,'Resident Evil 2[b] is a survival horror game developed and published by Capcom for the PlayStation in 1998. The player controls Leon S. Kennedy and Claire Redfield, who must escape Raccoon City after its citizens are transformed into zombies by a biological weapon two months after the events of the original Resident Evil. The gameplay focuses on exploration, puzzles, and combat; the main difference from its predecessor are the branching paths, with each player character having unique storylines and obstacles.');
INSERT INTO GameMock VALUES('Resident Evil 3','1999-9-22',NULL,'Resident Evil 3: Nemesis[a] is a survival horror video game developed by Capcom and released for the PlayStation in 1999. It is the third installment in the Resident Evil series and takes place around the events of Resident Evil 2. The story follows Jill Valentine and her efforts to escape from a city infected with a biological weapon. Choices through the game affect the story and ending. The game uses the same engine as its predecessors and features 3D models over pre-rendered backgrounds with fixed camera angles.');
INSERT INTO GameMock VALUES('Resident Evil Code Veronica','2000-02-03',NULL,'Resident Evil – Code: Veronica[a] is a survival horror video game developed and published by Capcom and released for the Dreamcast in 2000. It is the fourth major installment in the Resident Evil series and the first to debut on a separate platform from the PlayStation. The story takes place three months after the events of Resident Evil 2 (1998) and the concurrent destruction of Raccoon City as seen in Resident Evil 3: Nemesis (1999). It follows Claire Redfield and her brother Chris Redfield in their efforts to survive a viral outbreak at both a remote prison island in the Southern Ocean and a research facility in Antarctica. The game retains the traditional survival horror controls and gameplay seen in previous series installments; however, unlike the pre-rendered backgrounds of previous games, Code: Veronica utilizes real-time 3D environments and dynamic camera movement.');
INSERT INTO GameMock VALUES('Resident Evil 4','2005-01-11',NULL,'Resident Evil 4[a] is a third-person shooter survival horror video game developed by Capcom Production Studio 4[1] and published by Capcom. The sixth major installment in the Resident Evil series, it was originally released for the GameCube in 2005. Players control U.S. government special agent Leon S. Kennedy, who is sent on a mission to rescue the U.S. presidents daughter Ashley Graham, who has been kidnapped by a cult. In a rural part of Europe, Leon fights hordes of villagers infected by a mind-controlling parasite, and reunites with the spy Ada Wong.');
INSERT INTO GameMock VALUES('Resident Evil Revelations','2012-02-26',NULL,'Resident Evil: Revelations[a] is a survival horror video game developed by Capcom and originally released for the Nintendo 3DS handheld game console in 2012. Set between the Resident Evil titles Resident Evil 4 and Resident Evil 5, the game follows counter-terrorism agents Jill Valentine and Chris Redfield as they try to stop a bioterrorist organization from infecting the Earths oceans with a virus. The game features a single-player mode where the player must complete a series of episodes that involve solving puzzles and defeating enemies, and a multiplayer mode where players may fight their way through altered single-player scenarios.');
INSERT INTO GameMock VALUES('Resident Evil 5','2009-03-05',NULL,'Resident Evil 5[a] is a third-person shooter video game developed and published by Capcom. It is the seventh major installment in the Resident Evil series, and was announced in 2005—the same year its predecessor Resident Evil 4 was released. Resident Evil 5 was released for the PlayStation 3 and Xbox 360 consoles in March 2009 and for Microsoft Windows in September that year. The plot involves an investigation of a terrorist threat by Bioterrorism Security Assessment Alliance agents Chris Redfield and Sheva Alomar in Kijuju, a fictional region of Africa. Chris learns that he must confront his past in the form of an old enemy, Albert Wesker, and his former partner, Jill Valentine.');
INSERT INTO GameMock VALUES('Resident Evil Revelations 2','2015-02-25',NULL,'Resident Evil: Revelations 2[a] is an episodic survival horror video game developed and published by Capcom as part of the Resident Evil series. The game is a follow up to Resident Evil: Revelations and Resident Evil 5. This marks the return of Claire Redfield as the protagonist, and the first time Barry Burton is a playable story character in the main series. The first installment was released in February 2015.');
INSERT INTO GameMock VALUES('Resident Evil 6','2012-10-02',NULL,'Resident Evil 6[a] is a third-person shooter game developed and published by Capcom. It was released for the PlayStation 3 and Xbox 360 in October 2012 and for Windows in March 2013. Players control several characters over 3 separate story campaigns, including long-time protagonists Leon S. Kennedy and Chris Redfield, alongside several newcomers such as Jake Muller, as they confront the force behind a worldwide bio-terrorist attack. Every campaign features a unique style in both tone and gameplay.')
INSERT INTO GameMock VALUES('Resident Evil 7','2018-05-24',NULL,'Resident Evil 7: Biohazard[a] is a survival horror game developed and published by Capcom, released in January 2017 for Windows, PlayStation 4, and Xbox One, and in May 2018 for the Nintendo Switch in Japan. Diverging from the more action-oriented Resident Evil 5 and Resident Evil 6, Resident Evil 7 returns to the franchises survival horror roots, emphasizing exploration. The player controls Ethan Winters as he searches for his wife in a derelict plantation occupied by a cannibal family, solving puzzles and fighting enemies. It is the first main series game to use a first-person view.')

-- My family
INSERT INTO CharacterMock VALUES('Rafael',    'A. Rabelo',    'rafaelrabelos',    'Example_Password',     'rafael_rabelo@live.com', 'M')
INSERT INTO CharacterMock VALUES('Claudia',   'A. Maia',      'c_maia',           'Example_Password',    'c_maia@example.com', 'F')
INSERT INTO CharacterMock VALUES('Alexia',    'A. Maia',      'recodeveronica',   'Example_Password',    'alexia_maia@example.com', 'F')

--Characters
INSERT INTO CharacterMock VALUES('Rebecca',   'Chambers',     'Reb_re',           'Reb_re_Password',      'Rebecca@capcom.com', 'F')
INSERT INTO CharacterMock VALUES('Billy',     'Coen',         'Bil_re',           'Bil_re_Password',      'Billy@capcom.com', 'M')
INSERT INTO CharacterMock VALUES('Albert',    'Wesker',       'Alb_re',           'Alb_re_Password',      'Albert@capcom.com', 'M')
INSERT INTO CharacterMock VALUES('Chris',     'Redfield',     'Chr_re',           'Chr_re_Password',      'Chris@capcom.com', 'M')
INSERT INTO CharacterMock VALUES('Jill',      'Valentine',    'Jil_re',           'Jil_re_Password',      'Jill@capcom.com', 'F')
INSERT INTO CharacterMock VALUES('Barry',     'Burton',       'Bar_re',           'Bar_re_Password',      'Barry@capcom.com', 'M')
INSERT INTO CharacterMock VALUES('Brad',      'Vickers',      'Bra_re',           'Bra_re_Password',      'Brad@capcom.com', 'M')
INSERT INTO CharacterMock VALUES('Leon',      'S. Kennedy',   'Leo_re',           'Leo_re_Password',      'Leon@capcom.com', 'M')
INSERT INTO CharacterMock VALUES('Claire',    'Redfield',     'Cla_re',           'Cla_re_Password',      'Claire@capcom.com', 'F')
INSERT INTO CharacterMock VALUES('Ada',       'Wong',         'Ada_re',           'Ada_re_Password',      'Ada@capcom.com', 'F')
INSERT INTO CharacterMock VALUES('Sherry',    'Birkin',       'She_re',           'She_re_Password',      'Sherry@capcom.com', 'F')
INSERT INTO CharacterMock VALUES('HUNK',      'H. UNK',       'HUN_re',           'HUN_re_Password',      'HUNK@capcom.com', 'M')
INSERT INTO CharacterMock VALUES('Carlos',    'Oliveira',     'Car_re',           'Car_re_Password',      'Carlos@capcom.com', 'M')
INSERT INTO CharacterMock VALUES('Mikhail',   'Viktor',       'Mik_re',           'Mik_re_Password',      'Mikhail@capcom.com', 'M')
INSERT INTO CharacterMock VALUES('Nikolai',   'Zinoviev',     'Nik_re',           'Nik_re_Password',      'Nikolai@capcom.com', 'M')
INSERT INTO CharacterMock VALUES('Steve',     'Burnside',     'Ste_re',           'Ste_re_Password',      'Steve@capcom.com', 'M')
INSERT INTO CharacterMock VALUES('Ashley',    'Graham',       'Ash_re',           'Ash_re_Password',      'Ashley@capcom.com', 'F')
INSERT INTO CharacterMock VALUES('Ingrid',    'Hunnigan',     'Ing_re',           'Ing_re_Password',      'Ingrid@capcom.com', 'F')
INSERT INTO CharacterMock VALUES('Jack',      'Krauser',      'Jac_re',           'Jac_re_Password',      'Jack@capcom.com', 'M')
INSERT INTO CharacterMock VALUES('Luis',      'Sera',         'Lui_re',           'Lui_re_Password',      'Luis@capcom.com', 'M')
INSERT INTO CharacterMock VALUES('Parker',    'Luciani',      'Par_re',           'Par_re_Password',      'Parker@capcom.com', 'M')
INSERT INTO CharacterMock VALUES('Jessica',   'Sherawat',     'Jes_re',           'Jes_re_Password',      'Jessica@capcom.com', 'F')
INSERT INTO CharacterMock VALUES('Keith',     'Lumley',       'Kei_re',           'Kei_re_Password',      'Keith@capcom.com', 'M')
INSERT INTO CharacterMock VALUES('Quint',     'Cetcham',      'Qui_re',           'Qui_re_Password',      'Quint@capcom.com', 'M')
INSERT INTO CharacterMock VALUES('Raymond',   'Vester',       'Ray_re',           'Ray_re_Password',      'Raymond@capcom.com', 'M')
INSERT INTO CharacterMock VALUES('Sheva',     'Alomar',       'Sheva_re',           'She_re_Password',      'Sheva@capcom.com', 'F')
INSERT INTO CharacterMock VALUES('Josh',      'Stone',        'Jos_re',           'Jos_re_Password',      'Josh@capcom.com', 'M')
INSERT INTO CharacterMock VALUES('Excella',   'Gionne',       'Exc_re',           'Exc_re_Password',      'Excella@capcom.com', 'F')
INSERT INTO CharacterMock VALUES('Moira',     'Burton',       'Moi_re',           'Moi_re_Password',      'Moira@capcom.com', 'F')
INSERT INTO CharacterMock VALUES('Natalia',   'Korda',        'Nat_re',           'Nat_re_Password',      'Natalia@capcom.com', 'F')
INSERT INTO CharacterMock VALUES('Alex',      'Wesker',       'Ale_re',           'Ale_re_Password',      'Alex@capcom.com', 'M')
INSERT INTO CharacterMock VALUES('Jake',      'Muller',       'Jak_re',           'Jak_re_Password',      'Jake@capcom.com', 'M')
INSERT INTO CharacterMock VALUES('Piers',     'Nivans',       'Pie_re',           'Pie_re_Password',      'Piers@capcom.com', 'M')
INSERT INTO CharacterMock VALUES('Helena',    'Harper',       'Hel_re',           'Hel_re_Password',      'Helena@capcom.com', 'F')
INSERT INTO CharacterMock VALUES('Carla',     'Radames',      'Carla_re',           'Car_re_Password',      'Carla@capcom.com', 'F')
INSERT INTO CharacterMock VALUES('Ethan',     'Winters',      'Eth_re',           'Eth_re_Password',      'Ethan@capcom.com', 'M')
INSERT INTO CharacterMock VALUES('Mia',       'Winters',      'Mia_re',           'Mia_re_Password',      'Mia@capcom.com', 'F')
INSERT INTO CharacterMock VALUES('Joe',       'Baker',        'Joe_re',           'Joe_re_Password',      'Joe@capcom.com', 'M')
