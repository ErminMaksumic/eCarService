# eCarService

# Login credentials:


- [Desktop] Role: Administrator + Car service owner

    ```
    Username: admin   
    Password: admin                                     
    ```
    
- [Mobile] Role: Mobile user

    ```
    Username: mobile
    Password: mobile          
    ```

## Additional profile

- [Desktop] Role: Car service owner (without admin role)

    ```
    Username: serviceUser
    Password: serviceUser           
    ```    

## Stripe payment - Valid card number

    
    Card number: 4242 4242 4242 4242
   
 

# Running the app

    git clone https://github.com/ErminMaksumic/eCarService.git
   


## [Terminal] Use following commands


    docker-compose build
    docker-compose up
    

## [Terminal / Android Studio / ...]

    flutter pub get
	flutter run / flutter run --dart-define=baseUrl=http://[yourIp]:5045/api/

