import js from '@eslint/js';

export default [
  js.configs.recommended,
  {
    ignores: ['**/dist', '**/out-tsc', '**/node_modules', '**/.next'],
  },
  {
    files: ['**/*.ts', '**/*.tsx', '**/*.js', '**/*.jsx'],
    rules: {},
  },
];