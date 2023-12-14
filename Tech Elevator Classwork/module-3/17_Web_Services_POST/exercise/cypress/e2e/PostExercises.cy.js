describe("Web API (POST) Exercises", () => {

  describe('Part One: CRUD Topics', () => {

    it('Step One Tests: should create new topic', () => {
      cy.visit('/topic/create')
      cy.get('input[name="title"]').type('This is a TEST title for a new topic');
      cy.get('button.btn-submit').click();
      cy.contains('This is a TEST title for a new topic');
      cy.get('div.topic').should('have.length', 21);
    });

    it('Step Two Tests: should update the new topic', () => {
      cy.visit('/');
      cy.contains('This is a TEST title for a new topic');
      cy.get('div.topic a').last().click();
      cy.get('button.btn-edit').click();
      cy.get('input[name="title"]').clear().type('Updated TEST title');
      cy.get('button.btn-submit').click();
      cy.contains('Updated TEST title');
    });

    it('Step Three Tests: should delete the new topic', () => {
      cy.visit('/');
      cy.contains('Updated TEST title');
      cy.get('div.topic a').last().click();
      cy.get('button.btn-delete').click();
      cy.visit('/');
      cy.get('div.topic').should('have.length', 20);
    });

  });

  describe('Part Two: CRUD Messages', () => {

    it('Step One Tests: should create new message', () => {
      cy.visit('/topic/1/message/create')
      cy.get('input[name="title"]').type('TEST TITLE');
      cy.get('textarea[name="messageText"]').type('TEST MESSAGE TEXT');
      cy.get('button.btn-submit').click();
      cy.contains('TEST TITLE');
      cy.contains('TEST MESSAGE TEXT')
      cy.get('.message').should('have.length', 5);
    });

    it('Step Two Tests: should update the new message', () => {
      cy.visit('/topic/1');
      cy.get('.message').last().click();
      cy.get('button.btn-edit').click();
      cy.get('input[name="title"]').clear().type('UPDATED TEST TITLE');
      cy.get('textarea[name="messageText"]').clear().type('UPDATED TEST MESSAGE TEXT');
      cy.get('button.btn-submit').click();
      cy.contains('UPDATED TEST TITLE');
      cy.contains('UPDATED TEST MESSAGE TEXT')
    });

    it('Step Three Tests: should delete the new message', () => {
      cy.visit('/topic/1');
      cy.get('.message').last().click();
      cy.contains('UPDATED TEST TITLE');
      cy.contains('UPDATED TEST MESSAGE TEXT');
      cy.get('button.btn-delete').click();
      cy.get('.message').should('have.length', 4);
    });

  });

});
