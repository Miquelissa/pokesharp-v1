/* Regions */
INSERT INTO [dbo].[Region] ([Name], [Enabled], [CreatedAt], [UpdatedAt]) VALUES ('Kanto', 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)

/* Locals */
INSERT INTO [dbo].[Local] ([RegionID], [Enabled], [CreatedAt], [UpdatedAt], [ImageID], [Name]) VALUES (1, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 'pallet_town', 'Pallet Town')
INSERT INTO [dbo].[Local] ([RegionID], [Enabled], [CreatedAt], [UpdatedAt], [ImageID], [Name]) VALUES (1, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 'route_1', 'Route 1')
INSERT INTO [dbo].[Local] ([RegionID], [Enabled], [CreatedAt], [UpdatedAt], [ImageID], [Name]) VALUES (1, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 'route_2', 'Route 2')

/* Pallet Town */
INSERT INTO dbo.LocalPokemon (LocalID, PokemonID, Rarity, MinimumLevel, MaximumLevel, Enabled, CreatedAt, UpdatedAt) VALUES (1, (select ID from dbo.Pokemon where Name = 'Magikarp'), 'Common', 5, 5, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
INSERT INTO dbo.LocalPokemon (LocalID, PokemonID, Rarity, MinimumLevel, MaximumLevel, Enabled, CreatedAt, UpdatedAt) VALUES (1, (select ID from dbo.Pokemon where Name = 'Poliwag'), 'Uncommon', 10, 10, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
INSERT INTO dbo.LocalPokemon (LocalID, PokemonID, Rarity, MinimumLevel, MaximumLevel, Enabled, CreatedAt, UpdatedAt) VALUES (1, (select ID from dbo.Pokemon where Name = 'Goldeen'), 'Uncommon', 10, 10, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
INSERT INTO dbo.LocalPokemon (LocalID, PokemonID, Rarity, MinimumLevel, MaximumLevel, Enabled, CreatedAt, UpdatedAt) VALUES (1, (select ID from dbo.Pokemon where Name = 'Poliwag'), 'Uncommon', 15, 15, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
INSERT INTO dbo.LocalPokemon (LocalID, PokemonID, Rarity, MinimumLevel, MaximumLevel, Enabled, CreatedAt, UpdatedAt) VALUES (1, (select ID from dbo.Pokemon where Name = 'Tentacool'), 'Uncommon', 15, 15, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
INSERT INTO dbo.LocalPokemon (LocalID, PokemonID, Rarity, MinimumLevel, MaximumLevel, Enabled, CreatedAt, UpdatedAt) VALUES (1, (select ID from dbo.Pokemon where Name = 'Tentacool'), 'Uncommon', 10, 20, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
INSERT INTO dbo.LocalPokemon (LocalID, PokemonID, Rarity, MinimumLevel, MaximumLevel, Enabled, CreatedAt, UpdatedAt) VALUES (1, (select ID from dbo.Pokemon where Name = 'Staryu'), 'Common', 10, 5, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);

/* Route 1 */
INSERT INTO dbo.LocalPokemon (LocalID, PokemonID, Rarity, MinimumLevel, MaximumLevel, Enabled, CreatedAt, UpdatedAt) VALUES (2, (select ID from dbo.Pokemon where Name = 'Pidgey'), 'Common', 2, 2, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
INSERT INTO dbo.LocalPokemon (LocalID, PokemonID, Rarity, MinimumLevel, MaximumLevel, Enabled, CreatedAt, UpdatedAt) VALUES (2, (select ID from dbo.Pokemon where Name = 'Pidgey'), 'Common', 2, 2, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
INSERT INTO dbo.LocalPokemon (LocalID, PokemonID, Rarity, MinimumLevel, MaximumLevel, Enabled, CreatedAt, UpdatedAt) VALUES (2, (select ID from dbo.Pokemon where Name = 'Rattata'), 'Uncommon', 2, 2, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
INSERT INTO dbo.LocalPokemon (LocalID, PokemonID, Rarity, MinimumLevel, MaximumLevel, Enabled, CreatedAt, UpdatedAt) VALUES (2, (select ID from dbo.Pokemon where Name = 'Rattata'), 'Uncommon', 2, 2, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
INSERT INTO dbo.LocalPokemon (LocalID, PokemonID, Rarity, MinimumLevel, MaximumLevel, Enabled, CreatedAt, UpdatedAt) VALUES (2, (select ID from dbo.Pokemon where Name = 'Pikachu'), 'Legendary', 5, 5, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);

/* Route 2 */
INSERT INTO dbo.LocalPokemon (LocalID, PokemonID, Rarity, MinimumLevel, MaximumLevel, Enabled, CreatedAt, UpdatedAt) VALUES (3, (select ID from dbo.Pokemon where Name = 'Caterpie'), 'Mythical', 3, 3, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
INSERT INTO dbo.LocalPokemon (LocalID, PokemonID, Rarity, MinimumLevel, MaximumLevel, Enabled, CreatedAt, UpdatedAt) VALUES (3, (select ID from dbo.Pokemon where Name = 'Weedle'), 'Mythical', 3, 3, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
INSERT INTO dbo.LocalPokemon (LocalID, PokemonID, Rarity, MinimumLevel, MaximumLevel, Enabled, CreatedAt, UpdatedAt) VALUES (3, (select ID from dbo.Pokemon where Name = 'Pidgey'), 'Uncommon', 3, 3, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
INSERT INTO dbo.LocalPokemon (LocalID, PokemonID, Rarity, MinimumLevel, MaximumLevel, Enabled, CreatedAt, UpdatedAt) VALUES (3, (select ID from dbo.Pokemon where Name = 'Pidgey'), 'Uncommon', 3, 5, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
INSERT INTO dbo.LocalPokemon (LocalID, PokemonID, Rarity, MinimumLevel, MaximumLevel, Enabled, CreatedAt, UpdatedAt) VALUES (3, (select ID from dbo.Pokemon where Name = 'Rattata'), 'Uncommon', 2, 2, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
INSERT INTO dbo.LocalPokemon (LocalID, PokemonID, Rarity, MinimumLevel, MaximumLevel, Enabled, CreatedAt, UpdatedAt) VALUES (3, (select ID from dbo.Pokemon where Name = 'Rattata'), 'Uncommon', 3, 3, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
INSERT INTO dbo.LocalPokemon (LocalID, PokemonID, Rarity, MinimumLevel, MaximumLevel, Enabled, CreatedAt, UpdatedAt) VALUES (3, (select ID from dbo.Pokemon where Name = 'Nidoran♀'), 'Mythical', 4, 6, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
INSERT INTO dbo.LocalPokemon (LocalID, PokemonID, Rarity, MinimumLevel, MaximumLevel, Enabled, CreatedAt, UpdatedAt) VALUES (3, (select ID from dbo.Pokemon where Name = 'Nidoran♂'), 'Mythical', 4, 6, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
INSERT INTO dbo.LocalPokemon (LocalID, PokemonID, Rarity, MinimumLevel, MaximumLevel, Enabled, CreatedAt, UpdatedAt) VALUES (3, (select ID from dbo.Pokemon where Name = 'Mr. Mime'), 'Legendary', 1, 100, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
INSERT INTO dbo.LocalPokemon (LocalID, PokemonID, Rarity, MinimumLevel, MaximumLevel, Enabled, CreatedAt, UpdatedAt) VALUES (3, (select ID from dbo.Pokemon where Name = 'Mr. Mime'), 'Legendary', 1, 100, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
