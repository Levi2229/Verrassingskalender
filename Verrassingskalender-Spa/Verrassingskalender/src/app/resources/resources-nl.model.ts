/*
 * In een echte oplossing zou dit middels localization gedaan worden, dan zou dit waarschijnlijk een json file zijn. i.p.v. een const.
 * Dan zouden er aparte language files ingeladen kunnen worden op basis van de locatie of voorkeur van de gebruiker.
 */

export const resources = {
  formLabels: {
    name: 'naam',
  },
  landingPage: {
    startGame: 'Start spel',
    catchPhrase:
      'U gaat meedoen met de Verrassingskalender van De Nederlandse Loterij.',
    explanationTitle: 'Speluitleg',
    explanation:
      'U kunt uw naam hieronder invullen, hierna mag u één vakje kiezen om weg te krassen in het kalender. Dan ziet u direct of u een prijs gewonnen heeft. Hier zitten geen kosten aan verbonden. Wij slaan wel uw naam op om uw deelname te kunnen registreren.',
    odds: 'U hebt in dit kansspel 1% kans op een prijs van €100 en 0.01% kans op de hoofdprijs van €25000!',
    disclaimer:
      'Door te spelen stemt u in met <a href=\'https://www.nederlandseloterij.nl/disclaimer\' target="_blank">de disclaimer van De Nederlandse Loterij.</a>',
  },
  grid: {
    wonNothing: 'U heeft helaas geen prijs gewonnen, bedankt voor het spelen!',
    wonGrandPrize: 'U heeft de hoofdprijs van €25000 gewonnen, gefeliciteerd!',
    wonConsolationPrize: 'U heeft een prijs van €100 gewonnen, gefeliciteerd!',
  },
  formValidationMessage: {
    missingNameError: 'Vul uw naam in om te kunnen spelen.',
  },
};
