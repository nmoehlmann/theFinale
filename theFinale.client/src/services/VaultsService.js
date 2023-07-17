import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"
import {Vault} from "../models/Vault"

class VaultsService {
    async createVault(vaultData) {
        const res = await api.post('api/vaults', vaultData)
        logger.log('vault res.data', res.data)
        AppState.vaults.push(new VaultsService(res.data))
        logger.log(AppState.vaults, 'vaults appstate')
    }

    async getMyVaults() {
        const res = await api.get('account/vaults')
        logger.log('my vaults res.data', res.data)
        AppState.vaults = res.data.map(v => new Vault(v))
        logger.log('vaults appstate', AppState.vaults)
    }
}

export const vaultsService = new VaultsService()