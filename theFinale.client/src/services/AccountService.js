import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import { Vault } from "../models/Vault.js"
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      const myVaults = await api.get('/account/vaults')
      AppState.account = new Account(res.data)
      AppState.myVaults = myVaults.map(v => new Vault(v))
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }
}

export const accountService = new AccountService()