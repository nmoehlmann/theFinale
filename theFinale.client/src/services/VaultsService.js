import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"
import {Vault} from "../models/Vault"

class VaultsService {
    async createVault(vaultData) {
        const res = await api.post('api/vaults', vaultData)
        logger.log('vault res.data', res.data)
        AppState.vaults.push(new Vault(res.data))
        logger.log(AppState.vaults, 'vaults appstate')
    }

    async getMyVaults() {
        const res = await api.get('account/vaults')
        logger.log('my vaults res.data', res.data)
        AppState.vaults = res.data.map(v => new Vault(v))
        logger.log('vaults appstate', AppState.vaults)
    }

    async getUserVaults(profileId) {
        const res = await api.get(`api/profiles/${profileId}/vaults`)
        AppState.vaults = res.data.map(v => new Vault(v))
        logger.log(AppState.vaults)
    }

    async getVaultById(vaultId) {
        const res = await api.get(`api/vaults/${vaultId}`)
        AppState.activeVault = new Vault(res.data)
        logger.log(AppState.activeVault)
    }

    async deleteVault(vaultId) {
        await api.delete(`api/vaults/${vaultId}`)
        AppState.vaults = AppState.vaults.filter(v => v.id != vaultId)
    }

    async updateVault(vaultId, updateData) {
        const res = await api.put(`api/vaults/${vaultId}`, updateData)
        AppState.activeVault = new Vault(res.data)
        logger.log(AppState.activeVault)
    }
}

export const vaultsService = new VaultsService()