import nextEslintPluginNext from '@next/eslint-plugin-next';
import js from '@eslint/js';
import tseslint from 'typescript-eslint';
import reactPlugin from 'eslint-plugin-react';
import reactHooksPlugin from 'eslint-plugin-react-hooks';

export default [
  js.configs.recommended,
  ...tseslint.configs.recommended,
  {
    plugins: {
      '@next/next': nextEslintPluginNext,
      'react': reactPlugin,
      'react-hooks': reactHooksPlugin,
    },
  },
  {
    ignores: ['.next/**/*', 'node_modules/**/*'],
  },
  {
    files: ['**/*.ts', '**/*.tsx'],
    rules: {
      ...nextEslintPluginNext.configs.recommended.rules,
      ...nextEslintPluginNext.configs['core-web-vitals'].rules,
    },
  },
];