-- Write queries to return the following:
-- The following changes are applied to the "dvdstore" database.**

-- 1. Add actors, Hampton Avenue, and Lisa Byway to the actor table.
INSERT INTO actor (first_name, last_name)
VALUES ('Hampton', 'Avenue'), ('Lisa', 'Byway')

-- 2. Add "Euclidean PI", "The epic story of Euclid as a pizza delivery boy in
-- ancient Greece", to the film table. The movie was released in 2008 in English.
-- Since its an epic, the run length is 3hrs and 18mins. There are no special
-- features, the film speaks for itself, and doesn't need any gimmicks. 

INSERT INTO film (title, description, release_year, language_id, length)
VALUES ('Euclidean PI', 'The epic story of Euclid as a pizza delivery boy in
-- ancient Greece', 2008, 1, 198)

-- 3. Hampton Avenue plays Euclid, while Lisa Byway plays his slightly
-- overprotective mother, in the film, "Euclidean PI". Add them to the film.

INSERT INTO film_actor (actor_id, film_id)
VALUES ((SELECT actor.actor_id FROM actor WHERE first_name = 'Hampton' AND last_name = 'Avenue'), (SELECT film_id FROM film WHERE title = 'Euclidean PI')), 
	   ((SELECT actor.actor_id FROM actor WHERE first_name = 'Lisa' AND last_name = 'Byway'), (SELECT film_id FROM film WHERE title = 'Euclidean PI'))

-- 4. Add Mathmagical to the category table.

INSERT INTO category (name)
VALUES ('Mathmagical')

-- 5. Assign the Mathmagical category to the following films, "Euclidean PI",
-- "EGG IGBY", "KARATE MOON", "RANDOM GO", and "YOUNG LANGUAGE"

INSERT INTO film_category (film_id, category_id)
VALUES((SELECT film_id FROM film WHERE title = 'Euclidean PI'), (SELECT category_id FROM category WHERE name = 'Mathmagical'))
 
UPDATE film_category 
SET category_id = (SELECT category_id FROM category WHERE name = 'Mathmagical')
WHERE film_id IN ( SELECT film_id FROM film WHERE title IN ('Euclidean PI','EGG IGBY','KARATE MOON','RANDOM GO','YOUNG LANGUAGE'))

-- 6. Mathmagical films always have a "G" rating, adjust all Mathmagical films
-- accordingly.
-- (5 rows affected)
UPDATE film
SET film.rating = 'G'
WHERE film_id IN (SELECT film_id FROM film_category WHERE category_id = 17) 

-- 7. Add a copy of "Euclidean PI" to all the stores.

INSERT INTO inventory (film_id, store_id)
VALUES ((SELECT film_id FROM film WHERE title  = 'Euclidean PI'), 1), ((SELECT film_id FROM film WHERE title  = 'Euclidean PI'), 2)


-- 8. The Feds have stepped in and have impounded all copies of the pirated film,
-- "Euclidean PI". The film has been seized from all stores, and needs to be
-- deleted from the film table. Delete "Euclidean PI" from the film table.
-- (Did it succeed? Why?)
--<Reference restraint caused a deletion failure>
DELETE
FROM film
WHERE title = 'Euclidean PI'


-- 9. Delete Mathmagical from the category table.
-- (Did it succeed? Why?)
--<Reference restraint caused a deletion failure>

DELETE 
FROM category
WHERE name = 'Mathmagical'


-- 10. Delete all links to Mathmagical in the film_category tale.
-- (Did it succeed? Why?)
--<Worked because we were not deleting Primary keys referenced in other tables, only foreign keys being reference from other tables>

DELETE 
FROM film_category
WHERE category_id = 17


-- 11. Retry deleting Mathmagical from the category table, followed by retrying
-- to delete "Euclidean PI".
-- (Did either deletes succeed? Why?)
-- <Deleting Mathmagical worked because we removed any references of the primary key, the title failed because it is still linked to film_actor>
DELETE 
FROM category
WHERE name = 'Mathmagical'

DELETE
FROM film
WHERE title = 'Euclidean PI'

-- 12. Check database metadata to determine all constraints of the film id, and
-- describe any remaining adjustments needed before the film "Euclidean PI" can
-- be removed from the film table.

--<We would have to remove "Euclidean PI" from the film_actor table and from the inventory of each store to remove it from the table>