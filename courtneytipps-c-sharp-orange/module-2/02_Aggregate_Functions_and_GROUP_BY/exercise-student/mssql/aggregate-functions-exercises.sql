-- The following queries utilize the "world" database.
-- Write queries for the following problems. 
-- Notes:
--   GNP is expressed in units of one million US Dollars
--   The value immediately after the problem statement is the expected number 
--   of rows that should be returned by the query.

-- 1. The name and state plus population of all cities in states that border Ohio 
-- (i.e. cities located in Pennsylvania, West Virginia, Kentucky, Indiana, and 
-- Michigan).  
-- The name and state should be returned as a single column called 
-- name_and_state and should contain values such as ‘Detroit, Michigan’.  
-- The results should be ordered alphabetically by state name and then by city 
-- name. 
-- (19 rows)

SELECT name + ', ' + district AS name_and_state, population
FROM city
WHERE district IN ('Pennsylvania', 'West Virginia', 'Kentucky', 'Indiana', 'Michigan')
ORDER BY district, name;

-- 2. The name, country code, and region of all countries in Africa.  The name and
-- country code should be returned as a single column named country_and_code 
-- and should contain values such as ‘Angola (AGO)’ 
-- (58 rows)

SELECT name + ' (' + code +')' AS country_and_code, region
FROM country
WHERE continent = 'Africa'
ORDER BY region, name;

-- 3. The per capita GNP (i.e. GNP multipled by 1000000 then divided by population) of all countries in the 
-- world sorted from highest to lowest. Recall: GNP is express in units of one million US Dollars 
-- (highest per capita GNP in world: 37459.26)

SELECT name, (gnp * 1000000) / population AS 'per capita GNP'
FROM country
WHERE population > 0
ORDER BY 'per capita GNP' DESC;

-- 4. The average life expectancy of countries in South America.
-- (average life expectancy in South America: 70.9461)

SELECT continent, AVG(lifeexpectancy) AS 'Average Life Expectancy'
FROM country
WHERE continent = 'South America'
GROUP BY continent;
-- 5. The sum of the population of all cities in California.
-- (total population of all cities in California: 16716706)

SELECT district, SUM(population) AS 'Total Population'
FROM city
WHERE district = 'California'
GROUP BY district;

-- 6. The sum of the population of all cities in China.
-- (total population of all cities in China: 175953614)

SELECT countrycode, SUM(population) AS 'Total Population'
FROM city
WHERE countrycode IN(
SELECT code
FROM country
WHERE code = 'CHN')
GROUP BY countrycode;

-- 7. The maximum population of all countries in the world.
-- (largest country population in world: 1277558000)

SELECT MAX(population) AS 'Highest Population'
FROM country


-- 8. The maximum population of all cities in the world.
-- (largest city population in world: 10500000)

SELECT MAX(population) AS 'largest city population'
FROM city

-- 9. The maximum population of all cities in Australia.
-- (largest city population in Australia: 3276207)
SELECT countrycode, MAX(population) AS 'largest city population'
FROM city
WHERE countrycode = 'AUS'
GROUP BY countrycode;

-- 10. The minimum population of all countries in the world.
-- (smallest_country_population in world: 50)

SELECT MIN(population) AS 'Highest Population'
FROM country

-- 11. The average population of cities in the United States.
-- (avgerage city population in USA: 286955.3795)

SELECT countrycode, AVG(population) AS 'average population'
FROM city
WHERE countrycode = 'USA'
GROUP BY countrycode;

-- 12. The average population of cities in China.
-- (average city population in China: 484720.6997 approx.)

SELECT countrycode, AVG(population) AS 'average population'
FROM city
WHERE countrycode = 'CHN'
GROUP BY countrycode;

-- 13. The surface area of each continent ordered from highest to lowest.
-- (largest continental surface area: 31881000, "Asia")

SELECT continent, SUM(surfacearea) AS 'total surface area'
FROM country
GROUP BY continent
ORDER BY 'total surface area' DESC;

-- 14. The highest population density (population divided by surface area) of all 
-- countries in the world. 
-- (highest population density in world: 26277.7777)

SELECT MAX(population / surfacearea) AS 'highest population density'
FROM country


-- 15. The population density and life expectancy of the top ten countries with the 
-- highest life expectancies in descending order. 
-- (highest life expectancies in world: 83.5, 166.6666, "Andorra")

SELECT TOP 10 lifeexpectancy, MAX(population / surfacearea) AS 'highest population density', name
FROM country
GROUP BY lifeexpectancy, name
ORDER BY lifeexpectancy DESC;

-- 16. The difference between the previous and current GNP of all the countries in 
-- the world ordered by the absolute value of the difference. Display both 
-- difference and absolute difference.
-- (smallest difference: 1.00, 1.00, "Ecuador")

SELECT (gnp - gnpold) AS 'diff', ABS(gnp - gnpold) AS absolute_difference, name
FROM country
WHERE gnp IS NOT NULL AND gnpold IS NOT NULL
ORDER BY absolute_difference;

-- 17. The average population of cities in each country (hint: use city.countrycode)
-- ordered from highest to lowest.
-- (highest avg population: 4017733.0000, "SGP")

SELECT AVG(population) average_population, countrycode
FROM city
GROUP BY countrycode
ORDER BY average_population DESC;
	
-- 18. The count of cities in each state in the USA, ordered by state name.
-- (45 rows)

SELECT district, COUNT(name) AS city_count
FROM city
WHERE countrycode = 'USA'
GROUP BY district
ORDER BY district;
	
-- 19. The count of countries on each continent, ordered from highest to lowest.
-- (highest count: 58, "Africa")

SELECT COUNT(name) country_count, continent
FROM country
GROUP BY continent
ORDER BY country_count DESC;
	
-- 20. The count of cities in each country ordered from highest to lowest.
-- (largest number of  cities ib a country: 363, "CHN")
SELECT COUNT(name) city_count, countrycode
FROM city
GROUP BY countrycode
ORDER BY city_count DESC;
	
-- 21. The population of the largest city in each country ordered from highest to 
-- lowest.
-- (largest city population in world: 10500000, "IND")

SELECT MAX(population) largest_city_pop, countrycode
FROM city
GROUP BY countrycode
ORDER BY largest_city_pop DESC;

-- 22. The average, minimum, and maximum non-null life expectancy of each continent 
-- ordered from lowest to highest average life expectancy. 
-- (lowest average life expectancy: 52.5719, 37.2, 76.8, "Africa")

SELECT AVG(lifeexpectancy) average_life, MIN(lifeexpectancy) min_life, MAX(lifeexpectancy) max_life, continent
FROM country
WHERE lifeexpectancy IS NOT NULL
GROUP BY continent
ORDER BY average_life;