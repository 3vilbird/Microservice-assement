# Microservice-assement

## Steps to run the setup

##### 1. Clone the repo.
##### 2. Make sure that you are in the parent directory (palce where docker-compose file exists).
##### 3. Issue the command docker-compose up
##### 4. Visit the below urls
      : http://localhost:8080/swagger/index.html  (CODE GENERATION SERVICE.)
      : http://localhost/swagger/index.html       (STORAGE SERVICE.)  




##### CODE GENERATION SERVICE

  - This  micro-service is responsible  for the generation of unique codes.
  - Input integer (number of codes to be generated. )
  - Out put time taken to generate the uniquecodes.



##### STORAGE SERVICE

  - This  micro-service is responsible to read and write the data to the data base.
  - Input List of unique codes
  - Out put acknowledgement of data write.


##### HOW DO WE ENSURE THAT THE GENERATED CODES ARE UNIQUE FOR THAT REQUEST + NO DUPLICATION IN THE DATABSE ?

Conditions:
  1. MAX length of the unique code should be 5 characters.
  2. No duplication is allowed in the data base.
  
  LETS' SEE DIFFERENT WAYS TO HANDLE THIS SITUATION.
  
 ##### Approach I:   
  
  1. First approach would be like get all the unique codes present in the data base before generating the new codes. 
  
  2. Put them in the hash set ( because all CRUD operation in the hash set will be done in Big 'O' of one , meaning faster comparisition).
  
  3. After generating the unique each time check weather it exists int the hash set or not, make sure the it does not exist in the newly generated set as well.
  
  4. No here we are trading with memory against the more network calls (how ? i will explain in the next approach )
  
  ##### Approach II:
   
   1.In the second approach generate all the unique codes .
   
   2.send them to the storage service and before insertion check for the duplication.
   
   3.If it exists then do not insert store it in the separate hash map.
   
   4.Once all the insertion is done return the duplicte items to the code generation service.
   
   5.Regenerate the unique codes check for the duplication send the newly generated codes to storage service.
   
   6.Repeate the process till the return count of duplicate is zero from the storage service.
   
   7.Here we are tading with the network calls against the memory.
  
  ##### Approach III:
  
  1. Third approch would be we should come up with some code generation algorithm wich will ensure that it generates
      unique code every time.
      
  
     
   
   
   
   
   



