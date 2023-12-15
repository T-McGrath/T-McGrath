# Exercises for Web API (POST)

This exercise continues the work on the previous messaging application. Before beginning, review the updated starter code. Your task is to enhance the application so it's useable by an administrator who must create, read, update, and delete both topics and messages.

## Before you begin

Run the command `npm install` in the project directory to install any dependencies. Then run the project using the command `npm run dev`.

To test the project and verify completion, you can run the tests using either of the following commands:

* `npm run test:e2e-headless` - This runs the tests in "headless" mode to display the results in the console. Tests run significantly faster this way, but you don't get the additional support of the Cypress UI.
* `npm run test:e2e` - This runs the tests using the Cypress user interface, which may provide extra help, like screenshots, when you're troubleshooting a failed test. 

Note: The application and tests can't run simultaneously. If the application is already running, you may see the tests fail with the following message:

```bash
ERROR: "json-server-test" exited with 1.
Error: server closed unexpectedly
```

If this occurs, stop the application in the terminal or run `npx kill-port 3000`, then try to run the tests again.

## Part One: CRUD Topics

Add methods to support the remaining CRUD operations for Topics in the `src/services/TopicService.js` file. 

### Step One: Create a new Topic

Use Postman to make a `POST` request to `/topics` and verify the service endpoint works. Then, in the `TopicService`, develop a new method that takes a topic as a parameter, performs a `POST` request to the URL `/topics`, and returns a `Promise`. 

In the `TopicForm` component, locate the `submitForm` method and the **TODO** for add. Update the code to call the create method you just added to `TopicService`. You'll need to add an `import` statement before making a call on the `TopicService` service object.

Remember to check the status code to ensure the request was successful (201). 

- On success, use the router to forward the user to the `HomeView`. 
- If there are errors, call the existing `handleErrorResponse` method, passing in the error response and the `verb` "adding" used to complete the notification message.

### Step Two: Update a Topic

Use Postman to make a `PUT` request to `/topics/:id` and verify the service endpoint works. Then, write a new `TopicService` method that takes a topic id and a topic as parameters, performs a `PUT` request to the URL `/topics/:id`, and returns a `Promise`. 

In the `TopicForm` component, locate the `submitForm` method and the **TODO** for edit. To complete the code, call the new update method from the `TopicService`. Remember to check the status code to ensure the request was successful (200). 

- On success, use the router to forward the user to the `TopicDetailsView`, setting the topic id param. 
- If there are errors, call the existing `handleErrorResponse` method, passing in the error response and the `verb` "updating" used to complete the notification message.

### Step Three: Delete a Topic

Use Postman to make a `DELETE` request to `/topics/:id` and verify the service endpoint works. Then, add a new method to `TopicService` that takes a topic id as a parameter, performs a `DELETE` request to the URL `/topics/:id`, and returns a `Promise`. 

Open the `TopicDetails` component and locate the `deleteTopic` method and the **TODO** for delete. Update this to call the new delete method from the `TopicService`. Remember to check the status code to ensure the request was successful (200). 

- On success, use the router to forward the user to the `HomeView`. 
- If there are errors, call the existing `handleErrorResponse` method, passing in the error response and the `verb` "deleting" used to complete the notification message.

### Step Four: Run tests

After completing these steps correctly, all tests under `Part One: CRUD Topics` pass.

> Note: If your tests fail with the error message "Too many elements found" refer to the section [_A note on the test runner_](#a-note-on-the-test-runner) near the end of this document.

## Part Two: CRUD Messages

Add methods to support the remaining CRUD operations for Messages in the `src/services/MessageService.js` file.

### Step One: Create a new Message

Use Postman to make a `POST` request to `/messages` and verify the service endpoint works. Then, write a new method that accepts a message as an argument, performs a `POST` request to the URL `/messages`, and returns a `Promise`. 

Open the `MessageForm` component and locate the `submitForm` method and the **TODO** for add. Update it to call the new create method from the `MessageService`. Remember to check the status code to ensure the request was successful (201). 

- On success, use the router to forward the user to the `TopicDetailsView`, setting the topic id param.
- If there are errors, call the existing `handleErrorResponse` method, passing in the error response and the `verb` "adding" used to complete the notification message.

### Step Two: Update a Message

Use Postman to perform a `PUT` request to `/messages/:id`, and verify the service endpoint works. Then, add a new method to the service object that accepts a message id and message as arguments, performs a `PUT` request to the URL `/messages/:id`, and returns a `Promise`. 

Open the `MessageForm` component and locate the `submitForm` method and the **TODO** for edit. Call the new update method from the `MessageService` to complete it. Remember to check the status code to ensure the request was successful (200). 

- On success, use the router to forward the user to the `MessageDetailsView`, setting the message id param. 
- If there are errors, call the existing `handleErrorResponse` method, passing in the error response and the `verb` "updating" used to complete the notification message.

### Step Three: Delete a Message

Use Postman to make a `DELETE` request to `/messages/:id` and verify the service endpoint works. Then, develop a new method that accepts a message id, performs a `DELETE` request to the URL `/messages/:id`, and returns a `Promise`. 

Open the `MessageDetails` component and locate the `deleteMessage` method and the **TODO** for delete. Update this to call the new delete method from the `MessageService`. Remember to check the status code to ensure the request was successful (200). 

- On success, use the router to forward the user to the `TopicDetailsView`, setting the topic id param. 
- If there are errors, call the existing `handleErrorResponse` method, passing in the error response and the `verb` "deleting" used to complete the notification message.

### Step Four: Run tests

After completing these steps correctly, all tests under `Part Two: CRUD Messages` pass.

> Note: If your tests fail with the error message "Too many elements found" refer to the following section [_A note on the test runner_](#a-note-on-the-test-runner).

## A note on the test runner

The exercises and tests use an NPM package called [json-server](https://www.npmjs.com/package/json-server) as the API server. The script restores the JSON-server data to a known starting state at the start of each test run. However, this restore only happens when you run the npm command. 

You may encounter problems if you test with the Cypress UI using the `npm run test:e2e` command and leave the UI open between test runs. Since this isn't running the npm command to restore the data before re-running the test, changes from previous test runs may exist, leading to test failures. 

If your tests fail, particularly with the message "Too many elements found", you may need to restore the test data. 

To do this, either:
* Close the Cypress UI and re-run `npm run test:e2e` to restore the data and re-launch the UI.
* Alternatively, leave the Cypress UI running, open _another_ terminal window, and run `npm run restore-db` to restore the data and reset JSON-server.
