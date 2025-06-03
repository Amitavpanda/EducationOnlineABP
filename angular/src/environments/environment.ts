 import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44382/',
  redirectUri: baseUrl,
  clientId: 'OnlineEducation_App',
  responseType: 'code',
  scope: 'offline_access OnlineEducation',
  requireHttps: true,
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'OnlineEducation',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44382',
      rootNamespace: 'Acme.OnlineEducation',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
