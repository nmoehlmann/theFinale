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
      AppState.myVaults = myVaults.data.map(v => new Vault(v))
      logger.log('my vaults', AppState.myVaults)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async updateAccount(updateData) {
    const res = await api.put(`account`, updateData)
    logger.log(res.data)
    AppState.account = new Account(res.data)
  }
}

export const accountService = new AccountService()