import { test, expect } from '@playwright/test';

test('carga la pagina de samples', async ({ page }) => {
  await page.goto('/samples');
  await expect(page.locator('h1')).toContainText('Samples');
});