class VaultsService {
    async createVault(vaultData) {
        const res = await api.post('api/vaults', vaultData)
        logger.log('vault res.data', res.data)
        AppState.vaults.push(new VaultsService(res.data))
        logger.log(AppState.vaults, 'vaults appstate')
    }
}

export const vaultsService = new VaultsService()