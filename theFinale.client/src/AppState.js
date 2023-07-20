import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},
  /** @type {import('./models/Keep.js').Keep} */
  keeps: [],
  /** @type {import('./models/Keep.js').Keep} */
  userKeeps: [],
  /** @type {import('./models/Keep.js').Keep} */
  activeKeep: {},
    /** @type {import('./models/Vault.js').Vault} */
    vaults: [],
    /** @type {import('./models/Vault.js').Vault} */
    myVaults: [],
    /** @type {import('./models/Vault.js').Vault} */
  activeVault: {},
    /** @type {import('./models/Account.js').Account} */
    profile: {},
    /** @type {import('./models/VaultKeep.js').VaultKeep} */
  keepsInVault: [],
  page: "",
  vaultSelector: false
})
