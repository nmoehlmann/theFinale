import { AppState } from "../AppState.js"
import { VaultKeep } from "../models/Keep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultKeepsService {
  async createVaultKeep(vkData) {
    const res = await api.post(`api/vaultKeeps`, vkData)
    AppState.keepsInVault.push(new VaultKeep(res.data))
  }

  async getVaultKeeps(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}/keeps`)
    AppState.keepsInVault = res.data.map(vk => new VaultKeep(vk))
    logger.log('keeps in vault', AppState.keepsInVault)
  }

  async deleteVaultKeep(vkId) {
    await api.delete(`api/vaultKeeps/${vkId}`)
    AppState.keepsInVault = AppState.keepsInVault.filter(vk => vk.id == vkId)
    logger.log('filtered keeps in vault after deletion', AppState.keepsInVault)
  }
}

export const vaultKeepsService = new VaultKeepsService()